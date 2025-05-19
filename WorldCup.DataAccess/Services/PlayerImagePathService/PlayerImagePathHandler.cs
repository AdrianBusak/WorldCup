using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.PlayerImagePathService
{
    internal class PlayerImagePathHandler : IPlayerImagePathHandler
    {

        public Task<string> LoadImage(string playerName)
        {
            throw new NotImplementedException();
        }

        public void SaveImage(string imagePath, string playerName)
        {
            throw new NotImplementedException();
        }
    }
}
