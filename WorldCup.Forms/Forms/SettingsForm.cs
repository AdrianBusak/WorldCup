using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.Forms.Forms
{
    public partial class SettingsForm : Form
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new AppSettings();
        public SettingsForm()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();
            Init();
        }

        private void Init()
        {
            if(_appSettings.Competition == rbMen.Tag.ToString())
            {
                rbMen.Checked = true;
            }
            else if (_appSettings.Competition == rbWomen.Tag.ToString())
            {
                rbWomen.Checked = true;
            }

            if(_appSettings.Language == rbEn.Tag.ToString())
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
            this.Close();
        }
    }
}
