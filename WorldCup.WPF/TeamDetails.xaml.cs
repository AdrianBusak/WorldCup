using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.DataAccess.Models;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        private NationalTeam _team;

        public TeamDetails(NationalTeam team)
        {
            InitializeComponent();
            _team = team;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(Window.OpacityProperty, animation);

            txtCountry.Text = _team.Country;
            txtCode.Text = _team.FifaCode;
            txtPlayed.Text = _team.GamesPlayed.ToString();
            txtWins.Text = _team.Wins.ToString();
            txtLosses.Text = _team.Losses.ToString();
            txtDraws.Text = _team.Draws.ToString();
            txtGoalsScored.Text = _team.GoalsFor.ToString();
            txtGoalsConceded.Text = _team.GoalsAgainst.ToString();
            txtGoalDiff.Text = _team.GoalDifferential.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
