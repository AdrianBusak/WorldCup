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
            txtCountry.Text = $"Country: {_team.Country}";
            txtCode.Text = $"FIFA Code: {_team.FifaCode}";
            txtPlayed.Text = $"Played: {_team.GamesPlayed}";
            txtWins.Text = $"Wins: {_team.Wins}";
            txtLosses.Text = $"Losses: {_team.Losses}";
            txtDraws.Text = $"Draws: {_team.Draws}";
            txtGoalsScored.Text = $"Goals Scored: {_team.GoalsFor}";
            txtGoalsConceded.Text = $"Goals Conceded: {_team.GoalsAgainst}";
            txtGoalDiff.Text = $"Goal Difference: {_team.GoalDifferential}";

            // Pokreni animaciju fade-in
            var animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(Window.OpacityProperty, animation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
