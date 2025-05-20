using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.PlayerImagePathService
{
    internal class PlayerImagePathHandler : IPlayerImagePathHandler
    {
        private const string PATH = @"assets\images.txt";
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void SaveImage(string imagePath, string playerName)
        {

            try
            {
                if (!File.Exists(PATH))
                {
                    File.Create(PATH).Close();
                }
                File.WriteAllText(PATH, $"{playerName}{DEL}{imagePath}\n");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
