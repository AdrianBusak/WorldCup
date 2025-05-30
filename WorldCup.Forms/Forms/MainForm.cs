using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;
using WorldCup.Forms.UserControls;

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
        public MainForm()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadNationalTeamsAsync();
        }

        #region WorldCup tab 1
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

        private async void tabPage2_Enter(object sender, EventArgs e)
        {

            InitPlayers();

        }

        private async void InitPlayers()
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

                flpFavorites.Controls.Add(playerUC);
            }
        }

        async Task InitOtherPlayers()
        {
            var players = await _dataRepository.GetPlayersFromFirstMatchAsync(_selectedTeam.FifaCode);

            if (players == null || players.Count == 0)
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

                flpOthers.Controls.Add(playerUC);
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

    }
}
