using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Helpers;

namespace WorldCup.DataAccess.Services.PlayerImagePathService
{
    internal class PlayerImagePathHandler : IPlayerImagePathHandler
    {
        private static readonly string PATH = SolutionRoot.GetPlayerImagePath();
        private const char DEL = '#';
        public async Task<string> LoadImage(string playerName)
        {
            try
            {
                if (!File.Exists(PATH))
                {
                    throw new FileNotFoundException();
                }

                var lines = File.ReadAllLines(PATH);
                var dict = lines.Select(l =>
                   l.Split(DEL))
                    .ToDictionary(p => p[0], p => p[1]);

                string? image = dict.GetValueOrDefault(playerName);
                if (image == null)
                {
                    throw new NullReferenceException();
                }

                return image;
            }
            catch (Exception)
            {
                throw new Exception("Error with loading player image.");
            }
        }

        public void SaveImage(string imagePath, string playerName)
        {
            try
            {
                File.AppendAllText(PATH, $"{playerName}{DEL}{imagePath}\n");
            }
            catch (Exception)
            {
                throw new Exception("Error with saving player image.");
            }
        }
    }
}
