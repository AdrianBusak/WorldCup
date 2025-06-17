using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;
using WorldCup.DataAccess.Services.AppSettingsService;

namespace WorldCup.Forms.Forms
{
    public partial class Settings : Form
    {
        DataRepository _dataRepository = new DataRepository();

        private AppSettings _appSettings;
        public Settings()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();
            Init();
        }

        private void Init()
        {
            if (_appSettings.Competition == rbWomen.Tag.ToString())
            {
                rbWomen.Checked = true;
            }
            else if (_appSettings.Competition == rbMen.Tag.ToString())
            {
                rbMen.Checked = true;
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _dataRepository.SaveSettings(CollectData());
            new MainForm().Show();
            this.Hide();

        }

        private AppSettings CollectData()
        {
            return new AppSettings
            {
                Language = gbLanguage.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked).Tag.ToString(),

                Competition = gbGender.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked).Tag.ToString(),

                DataSource = _appSettings.DataSource
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            ChangeCulture(_appSettings.Language);
        }

        void ChangeCulture(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);

            }
            catch (Exception)
            {
                MessageBox.Show("Error with changing culture.");
            }
            //// Restart forme
            //var newForm = new Settings();
            //newForm.Show();
            //this.Close(); // ili this.Close()
        }

        private void rbHr_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                string selectedLanguage = radio.Tag.ToString();
                ChangeCulture(selectedLanguage);
            }
        }

        private void rbEn_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                string selectedLanguage = radio.Tag.ToString();
                ChangeCulture(selectedLanguage);
            }
        }
    }
}
