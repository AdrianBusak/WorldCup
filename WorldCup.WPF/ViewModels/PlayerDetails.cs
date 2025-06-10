using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WorldCup.WPF.ViewModels
{
    public class PlayerDetails : INotifyPropertyChanged
    {
        private string _playerName;
        private ImageSource _playerImage;
        private int _playerNumber;

        public string PlayerName
        {
            get => _playerName;
            set { _playerName = value; OnPropertyChanged(nameof(PlayerName)); }
        }

        public ImageSource PlayerImage
        {
            get => _playerImage;
            set { _playerImage = value; OnPropertyChanged(nameof(PlayerImage)); }
        }

        public int PlayerNumber
        {
            get => _playerNumber;
            set { _playerNumber = value; OnPropertyChanged(nameof(PlayerNumber)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
