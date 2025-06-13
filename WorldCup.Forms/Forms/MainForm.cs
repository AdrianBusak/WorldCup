using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataAccess.Enums;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;
using WorldCup.Forms.Properties;
using WorldCup.Forms.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WorldCup.Forms.Forms
{
    public partial class MainForm : Form
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new AppSettings();

        private IDictionary<string, NationalTeam> nationalTeams = new Dictionary<string, NationalTeam>();
        private NationalTeam _selectedTeam;
        private IEnumerable<Player> players = new List<Player>();
        private IEnumerable<Player> favoritePlayers = new List<Player>();

        private IDictionary<string, PlayerDetails> playerStats = new Dictionary<string, PlayerDetails>();
        private IList<Match> _selectedCountryMatches = new List<Match>();

        public MainForm()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            var culture = new CultureInfo(_appSettings.Language);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            //await LoadNationalTeamsAsync();
        }

        #region WorldCup tab 1
        private async void tabPage1_Enter(object sender, EventArgs e)
        {
            await LoadNationalTeamsAsync();
        }
        private void btnConfirmFavoriteTeam_Click(object sender, EventArgs e)
        {
            SaveFavoriteTeam();
            btnConfirmFavoriteTeam.BackColor = Color.LightGreen;
        }

        private void ClearFavoritePlayers()
        {
            flpFavorites.Controls.Clear();
            favoritePlayers = new List<Player>();
            _dataRepository.SaveFavoritePlayers(favoritePlayers);
        }
        private void cbTeams_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearFavoritePlayers();
        }

        private void cbTeams_SelectedValueChanged(object sender, EventArgs e)
        {
            btnConfirmFavoriteTeam.BackColor = Color.LightCoral;
        }
        private void SaveFavoriteTeam()
        {
            RefreshSelectedTeam();

            if (_selectedTeam == null)
            {
                MessageBox.Show("Please select a team before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string selectedTeamKey = cbTeams.SelectedItem?.ToString() ?? string.Empty;

                _dataRepository.SaveFavoriteTeam(selectedTeamKey);
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving favorite team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadNationalTeamsAsync()
        {
            cbTeams.DataSource = null;
            cbTeams.Items.Clear();
            cbTeams.Text = "Loading...";
            cbTeams.Enabled = false;

            try
            {
                List<NationalTeam> teams = await _dataRepository.GetTeamsAsync();
                nationalTeams = teams
                    .ToDictionary(n => $"{n.Country} ({n.FifaCode})",
                                    n => n);

                cbTeams.Items.Clear();
                cbTeams.Enabled = true;
                cbTeams.DataSource = nationalTeams.Keys.ToArray();

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
                    cbTeams.SelectedItem = favoriteTeam;
                }
                else if (cbTeams.SelectedItem != null
                    && nationalTeams.ContainsKey(cbTeams.SelectedItem.ToString()!))
                {
                    _selectedTeam = nationalTeams[cbTeams.SelectedItem.ToString()!];
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error with loading favorite team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshSelectedTeam()
        {
            //todo napravit sa string.empty(cbteams.selecteditem.tostring())
            if (cbTeams.SelectedItem != null && nationalTeams.ContainsKey(cbTeams.SelectedItem.ToString()!))
            {
                _selectedTeam = nationalTeams[cbTeams.SelectedItem.ToString()!];
            }
            else
            {
                _selectedTeam = null;
            }
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #region Players tab 2
        private async void tabPage2_Enter(object sender, EventArgs e)
        {
            if (_selectedTeam == null)
            {
                MessageBox.Show("Please select a team first.");
                return;
            }

            await InitPlayers();
        }

        private async Task InitPlayers()
        {
            await InitFavoritePlayers();
            await InitOtherPlayers();

        }
        async Task InitFavoritePlayers()
        {
            favoritePlayers = await _dataRepository.LoadFavoritePlayers();

            flpFavorites.Controls.Clear();

            foreach (var player in favoritePlayers)
            {
                PlayerUC playerUC = new PlayerUC(player);

                playerUC.IsFavorite = favoritePlayers
                    .Any(p => p.Name == player.Name && p.ShirtNumber == player.ShirtNumber);
                playerUC.PlayerImage = _dataRepository.LoadPlayerImagePath(player.Name);

                flpFavorites.Controls.Add(playerUC);
            }
        }

        async Task InitOtherPlayers()
        {
            players = await _dataRepository.GetPlayersFromFirstMatchAsync(_selectedTeam.FifaCode);

            if (players == null || players.Count() == 0)
            {
                MessageBox.Show("No players found for the selected team.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            flpOthers.Controls.Clear();

            foreach (var player in players)
            {
                if (favoritePlayers.Any(p => p.Name == player.Name))
                {
                    continue;
                }

                PlayerUC playerUC = new PlayerUC(player);
                playerUC.IsFavorite = favoritePlayers
                    .Any(p => p.Name == player.Name && p.ShirtNumber == player.ShirtNumber);
                playerUC.PlayerImage = _dataRepository.LoadPlayerImagePath(player.Name);
                flpOthers.Controls.Add(playerUC);
            }
        }
        private void tabPage2_Leave(object sender, EventArgs e)
        {
            // Save images for favorite players
            foreach (var playerUC in flpFavorites.Controls.OfType<PlayerUC>())
            {
                if (!string.IsNullOrEmpty(playerUC.PlayerImage) && System.IO.File.Exists(playerUC.PlayerImage))
                {
                    _dataRepository.SavePlayerImage(playerUC.PlayerImage, playerUC.Player.Name);
                }
            }

            // Save images for other players
            foreach (var playerUC in flpOthers.Controls.OfType<PlayerUC>())
            {
                if (!string.IsNullOrEmpty(playerUC.PlayerImage) && System.IO.File.Exists(playerUC.PlayerImage))
                {
                    _dataRepository.SavePlayerImage(playerUC.PlayerImage, playerUC.Player.Name);
                }
            }
        }

        private void flpOthers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<PlayerUC>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flpOthers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(List<PlayerUC>))) return;

            var targetPanel = (FlowLayoutPanel)sender;
            var draggedList = e.Data.GetData(typeof(List<PlayerUC>)) as List<PlayerUC>;

            foreach (var uc in draggedList)
            {
                if (uc.Parent is FlowLayoutPanel currentPanel)
                {
                    currentPanel.Controls.Remove(uc);
                }

                uc.IsSelected = false;
                uc.IsFavorite = false;
                uc.BackColor = SystemColors.Control;
                targetPanel.Controls.Add(uc);
            }
        }

        private void flpFavorites_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(List<PlayerUC>))) return;


            var targetPanel = (FlowLayoutPanel)sender;
            var draggedList = e.Data.GetData(typeof(List<PlayerUC>)) as List<PlayerUC>;


            if (flpFavorites.Controls.Count >= 3 || (draggedList.Count + flpFavorites.Controls.Count) > 3)
            {
                MessageBox.Show("Can't add more then 3 players.");
                return;
            }

            foreach (var uc in draggedList)
            {
                if (uc.Parent is FlowLayoutPanel currentPanel)
                {
                    currentPanel.Controls.Remove(uc);
                }

                uc.IsSelected = false;
                uc.IsFavorite = true;
                uc.BackColor = SystemColors.Control;
                targetPanel.Controls.Add(uc);
            }

            SaveFavoritePlayers();
        }

        private void SaveFavoritePlayers()
        {
            favoritePlayers = flpFavorites.Controls
                            .OfType<PlayerUC>()
                            .Select(p => p.Player)
                            .ToList();

            _dataRepository.SaveFavoritePlayers(favoritePlayers);
        }

        private void flpFavorites_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<PlayerUC>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion

        #region Rang list tab 3
        private async void tabPage3_EnterAsync(object sender, EventArgs e)
        {
            await InitRangList();
            ShowRangList();

        }

        private void ShowRangList()
        {
            if (cbFilter.SelectedItem == null)
            {
                return;
            }

            if (cbFilter.SelectedItem is not FilterRangList selectedFilter)
            {
                return;
            }

            var playersStats = GetPlayersStats();
            var matchData = GetMatchData();

            switch (selectedFilter)
            {
                case FilterRangList.GOALS:
                    dataGridView1.DataSource =
                    playersStats.Select(p => new
                    {
                        p.Name,
                        p.GoalsCount,
                        Image = File.Exists(p.ImagePath) ? Image.FromFile(p.ImagePath) : Resources.football_player
                    })
                        .OrderByDescending(p => p.GoalsCount)
                        .ThenBy(p => p.Name)
                        .ToList();
                    break;

                case FilterRangList.YELLOW_CARDS:
                    dataGridView1.DataSource = playersStats.Select(p => new
                    {
                        p.Name,
                        p.YellowCardCount,
                        Image = File.Exists(p.ImagePath) ? Image.FromFile(p.ImagePath) : Resources.football_player
                    })
                        .OrderByDescending(p => p.YellowCardCount)
                        .ThenBy(p => p.Name)
                        .ToList();
                    break;

                case FilterRangList.MATCH:
                    dataGridView1.DataSource = matchData;

                    break;

                default:
                    break;
            }

            if (dataGridView1.Columns[2] is DataGridViewImageColumn imageColumn)
            {
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

        }

        private object GetMatchData()
        {
            return _selectedCountryMatches.Select(m => new
            {
                m.Location,
                VisitorsCount = m.Attendance,
                MatchDate = m.Datetime.ToString("dd/MM/yyyy"),
                HomeTeam = m.HomeTeam.Country,
                AwayTeam = m.AwayTeam.Country,
            }).ToList();
        }

        private IList<PlayerDetails> GetPlayersStats()
        {
            var playerStats = new Dictionary<string, PlayerDetails>();

            players.ToList().ForEach(player =>
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

            foreach (var match in _selectedCountryMatches)
            {
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
            }

            return playerStats
                .Select(p => p.Value)
                .ToList();
        }

        private async Task InitRangList()
        {
            await LoadRangListDataAsync();

            cbFilter.DataSource = Enum.GetValues(typeof(FilterRangList));

        }

        private async Task LoadRangListDataAsync()
        {
            List<Match> matches = await _dataRepository.GetCountryMatchesAsync(_selectedTeam.FifaCode);

            if (matches == null || matches.Count == 0)
            {
                MessageBox.Show("No matches found for the selected team.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _selectedCountryMatches = matches;
        }

        private void cbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowRangList();
        }

        private void btnPrintPdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                e.Graphics.DrawString("No data to print.", new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
                return;
            }
            int yPos = 100;
            int imageSize = 32;
            int imageX = 100;
            int textX = imageX + imageSize + 10;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Try to get the image from the "Image" column if it exists
                Image playerImage = null;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Name == "Image" && cell.Value is Image img)
                    {
                        playerImage = img;
                        break;
                    }
                }

                if (playerImage != null)
                {
                    e.Graphics.DrawImage(playerImage, new Rectangle(imageX, yPos, imageSize, imageSize));
                }

                // Prepare text (skip the image column)
                var cellValues = row.Cells.Cast<DataGridViewCell>()
                    .Where(c => c.OwningColumn.Name != "Image")
                    .Select(c => c.Value?.ToString() ?? "");

                string rowText = string.Join(" | ", cellValues);
                e.Graphics.DrawString(rowText, new Font("Arial", 10), Brushes.Black, new PointF(textX, yPos + (imageSize - 16) / 2));

                yPos += imageSize + 8;
            }
        }

        #endregion

        #region Settings tab 4
        private async void btnConfirmSettings_ClickAsync(object sender, EventArgs e)
        {
            DialogResult result = MessageBox
                .Show(
                "Are you sure you want to save the settings?",
                "Confirm Settings",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                CheckSettings();


                _appSettings = new AppSettings
                {
                    Language = gbLanguage.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked).Tag.ToString(),

                    Competition = gbGender.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked).Tag.ToString(),

                    DataSource = gbDataSource.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked).Tag.ToString()
                };

                _dataRepository.SaveSettings(_appSettings);
                MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var culture = new CultureInfo(_appSettings.Language);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;

                await LoadNationalTeamsAsync();


            }
        }

        private void CheckSettings()
        {
            string selectedCompetition = gbGender.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Tag.ToString();

            if (_appSettings.Competition != selectedCompetition)
            {
                favoritePlayers = new List<Player>();
                _dataRepository.SaveFavoritePlayers(favoritePlayers);

            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            InitSettings();
        }

        private void InitSettings()
        {
            if (_appSettings.Competition == rbMen.Tag.ToString())
            {
                rbMen.Checked = true;
            }
            else if (_appSettings.Competition == rbWomen.Tag.ToString())
            {
                rbWomen.Checked = true;
            }

            if (_appSettings.Language == rbJson.Tag.ToString())
            {
                rbJson.Checked = true;
            }
            else if (_appSettings.Language == rbApi.Tag.ToString())
            {
                rbApi.Checked = true;
            }

            if (_appSettings.Language == rbEn.Tag.ToString())
            {
                rbEn.Checked = true;
            }
            else if (_appSettings.Language == rbHr.Tag.ToString())
            {
                rbHr.Checked = true;
            }
        }

        private async void tabPage1_LeaveAsync(object sender, EventArgs e)
        {
            await LoadNationalTeamsAsync();
        }
        #endregion
    }
}
