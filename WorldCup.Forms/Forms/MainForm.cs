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

namespace WorldCup.Forms.Forms
{
    public partial class MainForm : Form
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new AppSettings();

        private Dictionary<string, NationalTeam> nationalTeams = new Dictionary<string, NationalTeam>();
        private NationalTeam _selectedTeam;
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
        

    }
}
