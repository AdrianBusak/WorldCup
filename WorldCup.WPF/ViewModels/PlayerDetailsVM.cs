using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WorldCup.DataAccess.Models;

namespace WorldCup.WPF.ViewModels
{
    public class PlayerDetailsVM : INotifyPropertyChanged
    {
        private ImageSource _playerImage;

        private PlayerDetails _player;
        public PlayerDetails Player
        {
            get => _player;
            set { _player = value; OnPropertyChanged(nameof(_player)); }
        }

        public ImageSource PlayerImage
        {
            get => _playerImage;
            set { _playerImage = value; OnPropertyChanged(nameof(PlayerImage)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
