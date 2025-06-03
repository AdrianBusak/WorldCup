using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.PlayerImagePathService
{
    public interface IPlayerImagePathHandler
    {
        void SaveImage(string imagePath, string playerName);
        string LoadImage(string playerName);
    }
}
