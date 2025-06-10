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

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new AppSettings();


        internal class MatchOption
        {
            public string Name { get; set; }
            public Match Match { get; set; }
            public override string ToString()
            => Name;
        }

        private IDictionary<string, NationalTeam> nationalTeams = new Dictionary<string, NationalTeam>();
        private IList<MatchOption> nationalTeamMatches = new List<MatchOption>();

        private NationalTeam _selectedTeam;
        private Team _selectedAwayTeam;
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

                cbAwayTeam.ItemsSource = nationalTeamMatches
                                            .ToList();
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
                }
                else if (cbHomeTeam.SelectedItem != null
                    && nationalTeams.ContainsKey(cbHomeTeam.SelectedItem.ToString()!))
                {
                    _selectedTeam = nationalTeams[cbHomeTeam.SelectedItem.ToString()!];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error with loading favorite team.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void On_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _dataRepository.SaveSettings(_appSettings);
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
                var selectedOption = cbAwayTeam.SelectedItem as MatchOption;
                if (selectedOption == null)
                    return;

                _selectedMatch = selectedOption.Match;

                _selectedAwayTeam = _selectedMatch.HomeTeam.Country == _selectedTeam.Country
                    ? _selectedMatch.AwayTeam
                    : _selectedMatch.HomeTeam;

                
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
                foreach (var player in homeTeam)
                {
                    PlayerControl control = new PlayerControl(new ViewModels.PlayerDetails
                    {
                        PlayerName = player.Name,
                        PlayerNumber = (int)player.ShirtNumber,
                        PlayerImage = LoadImageSource(_dataRepository.LoadPlayerImagePath(player.Name))
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
                foreach (var player in awayTeam)
                {
                    PlayerControl control = new PlayerControl(new ViewModels.PlayerDetails
                    {
                        PlayerName = player.Name,
                        PlayerNumber = (int)player.ShirtNumber,
                        PlayerImage = LoadImageSource(_dataRepository.LoadPlayerImagePath(player.Name))
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

            // Prvo resetuj prozor
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.ResizeMode = ResizeMode.CanResize;

            switch (mode)
            {
                case WindowMode.FULLSCREEN:
                    this.WindowState = WindowState.Maximized;
                    break;

                case WindowMode.HALFSCREEN:
                    this.Width = screenWidth / 2;
                    this.Height = screenHeight;
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
        
    }

}