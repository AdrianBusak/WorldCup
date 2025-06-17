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
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow(ViewModels.PlayerDetailsVM playerDetailsVM)
        {
            InitializeComponent();
            DataContext = playerDetailsVM;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var scaleUpX = new DoubleAnimation
            {
                From = 0.5,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var scaleUpY = new DoubleAnimation
            {
                From = 0.5,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            var transform = this.RenderTransform as ScaleTransform;
            transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUpX);
            transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUpY);
        }
        public PlayerDetailsWindow()
        {
            InitializeComponent();
            this.RenderTransform = new ScaleTransform();
        }
    }
}
