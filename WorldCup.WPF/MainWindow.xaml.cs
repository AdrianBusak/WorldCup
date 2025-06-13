using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldCup.DataAccess.Enums;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;
using WorldCup.WPF.Models;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new AppSettings();


        private Dictionary<string, NationalTeam> nationalTeams = new Dictionary<string, NationalTeam>();
        private List<MatchOption> nationalTeamMatches = new List<MatchOption>();

        private NationalTeam _selectedTeam;
        private NationalTeam _selectedAwayTeam;
        private Match _selectedMatch;

        private IEnumerable<StartingEleven> homeTeam = new List<StartingEleven>();
        private IEnumerable<StartingEleven> awayTeam = new List<StartingEleven>();
        public MainWindow()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();
            InitAsync();
        }

        private async void InitAsync()
        {
            ApplyWindowMode(_appSettings.WindowMode);

            try
            {
                await LoadNationalTeamsAsync();

                await LoadAwayTeamAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Error with loading data");
            }

        }

        private async Task LoadAwayTeamAsync()
        {
            try
            {
                if (_selectedTeam != null)
                {
                }
                IList<Match> matches = await _dataRepository.GetCountryMatchesAsync(_selectedTeam.FifaCode);
                nationalTeamMatches.Clear();
                foreach (Match match in matches)
                {
                    if (match.AwayTeam.Country != _selectedTeam.Country)
                    {
                        nationalTeamMatches.Add(new MatchOption
                        {
                            Name = $"{match.AwayTeam.Country} ({match.AwayTeam.Code})",
                            Match = match
                        });
                    }
                    else
                    {
                        nationalTeamMatches.Add(new MatchOption
                        {
                            Name = $"{match.HomeTeam.Country} ({match.HomeTeam.Code})",
                            Match = match
                        });
                    }
                }

                cbAwayTeam.ItemsSource = nationalTeamMatches.ToList();
            }
            catch (Exception)
            {

                throw new ArgumentException("");
            }
        }
        private async Task LoadNationalTeamsAsync()
        {
            cbHomeTeam.ItemsSource = null;
            cbHomeTeam.Text = "Loading...";
            cbHomeTeam.IsEnabled = false;

            try
            {
                List<NationalTeam> teams = await _dataRepository.GetTeamsAsync();
                nationalTeams = teams
                    .ToDictionary(n => $"{n.Country} ({n.FifaCode})", n => n);

                cbHomeTeam.ItemsSource = nationalTeams.Keys.ToList();
                cbHomeTeam.IsEnabled = true;
                cbHomeTeam.Text = null;

                SetFavoriteTeamSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Error with loading teams.");
            }
        }
        private void SetFavoriteTeamSelection()
        {
            try
            {
                string? favoriteTeam = _dataRepository.LoadFavoriteTeam();

                if (!string.IsNullOrEmpty(favoriteTeam) && nationalTeams.ContainsKey(favoriteTeam))
                {
                    _selectedTeam = nationalTeams[favoriteTeam];
                    cbHomeTeam.SelectedItem = favoriteTeam;
                    return;
                }
                else if (cbHomeTeam.SelectedItem != null
                    && nationalTeams.ContainsKey(cbHomeTeam.SelectedItem.ToString()!))
                {
                    _selectedTeam = nationalTeams[cbHomeTeam.SelectedItem.ToString()!];
                    return;
                }
                cbHomeTeam.SelectedIndex = 1;
                _selectedTeam = nationalTeams[cbHomeTeam.SelectedItem.ToString()!];
            }
            catch (Exception)
            {
                MessageBox.Show("Error with loading favorite team.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void On_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Question,
                MessageBoxResult.OK);

            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private async void On_SelectionChanged_HomeTeam(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ClearField();
                SaveFavoriteTeam();
                await LoadAwayTeamAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading away team: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbAwayTeam.SelectedItem is not MatchOption selectedOption)
                    return;

                _selectedMatch = selectedOption.Match;

                _selectedAwayTeam = nationalTeams[selectedOption.Name];



                RenderPlayersOnFieldAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting away team: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RenderPlayersOnFieldAsync()
        {
            try
            {
                ClearField();
                homeTeam = _dataRepository.GetPlayersFromMatch(_selectedMatch, _selectedTeam.Country);
                awayTeam = _dataRepository.GetPlayersFromMatch(_selectedMatch, _selectedAwayTeam.Country);

                if (homeTeam == null || !homeTeam.Any() || awayTeam == null || !awayTeam.Any())
                {
                    MessageBox.Show("No players found for the selected teams.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                InitPlayers();
                lbResult.Text = $"{_selectedMatch.HomeTeam.Country}|{_selectedMatch.HomeTeam.Goals}" +
                    $" : {_selectedMatch.AwayTeam.Goals}|{_selectedMatch.AwayTeam.Country}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rendering players: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void InitPlayers()
        {
            try
            {
                IList<PlayerDetails> playersStatsHome = GetPlayersStats(_selectedMatch, homeTeam.ToList());

                foreach (var player in playersStatsHome)
                {
                    PlayerControl control = new PlayerControl(new ViewModels.PlayerDetailsVM
                    {
                        Player = player,
                        PlayerImage = LoadImageSource(player.ImagePath)
                    });

                    switch (player.Position)
                    {
                        case Position.Goalie:
                            Zone0.Children.Add(control);
                            break;
                        case Position.Defender:
                            Zone1.Children.Add(control);
                            break;
                        case Position.Midfield:
                            Zone2.Children.Add(control);
                            break;
                        case Position.Forward:
                            Zone3.Children.Add(control);
                            break;
                    }

                }
                IList<PlayerDetails> playersStatsAway = GetPlayersStats(_selectedMatch, awayTeam.ToList());

                foreach (var player in playersStatsAway)
                {
                    PlayerControl control = new PlayerControl(new ViewModels.PlayerDetailsVM
                    {
                        Player = player,
                        PlayerImage = LoadImageSource(player.ImagePath)
                    });

                    switch (player.Position)
                    {
                        case Position.Goalie:
                            Zone7.Children.Add(control);
                            break;
                        case Position.Defender:
                            Zone6.Children.Add(control);
                            break;
                        case Position.Midfield:
                            Zone5.Children.Add(control);
                            break;
                        case Position.Forward:
                            Zone4.Children.Add(control);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing players: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private List<PlayerDetails> GetPlayersStats(Match match, List<StartingEleven> startingElevens)
        {
            var playerStats = new Dictionary<string, PlayerDetails>();

            startingElevens.ToList().ForEach(player =>
            {
                playerStats[player.Name] = new PlayerDetails
                {
                    Name = player.Name,
                    GoalsCount = 0,
                    YellowCardCount = 0,
                    Captain = player.Captain,
                    Position = player.Position,
                    ShirtNumber = player.ShirtNumber,
                    ImagePath = _dataRepository.LoadPlayerImagePath(player.Name)
                };
            });

            var allEvents = match.AwayTeamEvents.Concat(match.HomeTeamEvents);

            foreach (var e in allEvents)
            {
                if (!playerStats.ContainsKey(e.Player))
                {
                    continue;
                }

                if (e.TypeOfEvent == TypeOfEvent.Goal || e.TypeOfEvent == TypeOfEvent.GoalPenalty)
                {
                    playerStats[e.Player].GoalsCount += 1;
                }
                else if (e.TypeOfEvent == TypeOfEvent.YellowCard)
                {
                    playerStats[e.Player].YellowCardCount += 1;
                }

            }

            return playerStats
                .Select(p => p.Value)
                .ToList();
        }

        private void ClearField()
        {
            Zone0.Children.Clear();
            Zone1.Children.Clear();
            Zone2.Children.Clear();
            Zone3.Children.Clear();
            Zone4.Children.Clear();
            Zone5.Children.Clear();
            Zone6.Children.Clear();
            Zone7.Children.Clear();
            lbResult.Text = string.Empty;
        }

        private ImageSource LoadImageSource(string imagePath)
        {
            string fallbackPath = "pack://application:,,,/Assets/messi.jfif";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(
                string.IsNullOrEmpty(imagePath) ? fallbackPath : imagePath,
                UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            return bitmap;
        }

        private void SaveFavoriteTeam()
        {
            RefreshSelectedTeam();

            if (_selectedTeam == null)
            {
                MessageBox.Show("Please select a team before saving.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string selectedTeamKey = cbHomeTeam.SelectedItem?.ToString() ?? string.Empty;

                _dataRepository.SaveFavoriteTeam(selectedTeamKey);
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving favorite team.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RefreshSelectedTeam()
        {
            if (cbHomeTeam.SelectedItem != null && nationalTeams.ContainsKey(cbHomeTeam.SelectedItem.ToString()!))
            {
                _selectedTeam = nationalTeams[cbHomeTeam.SelectedItem.ToString()!];
            }
            else
            {
                _selectedTeam = null;
            }
        }
        private void ApplyWindowMode(WindowMode mode)
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.CanResize;

            switch (mode)
            {
                case WindowMode.FULLSCREEN:
                    this.WindowState = WindowState.Maximized;
                    break;

                case WindowMode.HALFSCREEN:
                    this.Width = screenWidth / 1.5;
                    this.Height = screenHeight / 1.5;
                    this.Left = 0;
                    this.Top = 0;
                    break;

                case WindowMode.QUARTERSCREEN:
                    this.Width = screenWidth / 2;
                    this.Height = screenHeight / 2;
                    this.Left = 0;
                    this.Top = 0;
                    break;
            }
        }

        private void btnDetailsHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamDetails teamDetails = new TeamDetails(_selectedTeam);
            teamDetails.Show();
        }

        private void btnDetailsAwayTeam_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAwayTeam != null)
            {
                TeamDetails teamDetails = new TeamDetails(_selectedAwayTeam);
                teamDetails.Show();
            }
            else
            {
                MessageBox.Show("Please select an away team first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsView settingsWindow = new SettingsView();
            settingsWindow.ShowDialog();
        }
    }
}