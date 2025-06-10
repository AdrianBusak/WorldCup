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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldCup.DataAccess.Models;
using WorldCup.WPF.ViewModels;

namespace WorldCup.WPF
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
            
            
        }
        public PlayerControl(ViewModels.PlayerDetailsVM playerDetails)
        {
            InitializeComponent();
            DataContext = playerDetails;

        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as PlayerDetailsVM;
            if (viewModel != null && viewModel.Player != null)
            {
                var playerDetailsWindow = new PlayerDetailsWindow(DataContext as PlayerDetailsVM);
                playerDetailsWindow.Show();
            }
        }
    }
}
