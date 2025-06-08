using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.DataAccess.Enums;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        DataRepository _dataRepository = new DataRepository();
        AppSettings _appSettings = new();
        public SettingsView()
        {
            InitializeComponent();
            _appSettings = _dataRepository.LoadSettings();
            InitData();
        }

        private void InitData()
        {
            cbWindowMode.ItemsSource = new List<string> { "HALFSCREEN", "FULLSCREEN", "QUARTERSCREEN" };
            cbCompetition.ItemsSource = new List<string> { "men", "women" };
            cbLanguage.ItemsSource = new List<string> { "English", "Croatian" };

            if(_appSettings.Language == "en")
            {
                cbLanguage.SelectedIndex = 0;
            }
            else if (_appSettings.Language == "hr")
            {
                cbLanguage.SelectedIndex = 1;
            }
            if(_appSettings.Competition == "men")
            {
                cbCompetition.SelectedIndex = 0;
            }
            else if(_appSettings.Competition == "women")
            {
                cbCompetition.SelectedIndex = 1;
            }

            cbWindowMode.SelectedItem = _appSettings.WindowMode.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ValidateForm();
            _dataRepository.SaveSettings(CollectData());


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private AppSettings CollectData()
        {
            AppSettings appSettings = new AppSettings();
            appSettings.Language = cbLanguage.SelectedIndex == 0 ? "en" : "hr";
            appSettings.Competition = cbCompetition.SelectedIndex == 0 ? "men" : "women";
            appSettings.WindowMode = (WindowMode)Enum.Parse(typeof(WindowMode), cbWindowMode.SelectedItem.ToString().ToUpper());

            return appSettings;
        }
    }
}
