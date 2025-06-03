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
        public string LoadImage(string playerName)
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Dispose();
            }

            try
            {
                var lines = File.ReadAllLines(PATH);
                foreach (var line in lines)
                {
                    var parts = line.Split(DEL);
                    if (parts.Length == 2 && parts[0] == playerName)
                        return parts[1]; // vrati path
                }

                return string.Empty; // nije nađen
            }
            catch
            {
                return string.Empty; // fallback
            }
        }


        public void SaveImage(string imagePath, string playerName)
        {
            string test = LoadImage(playerName);

            try
            {
                if (!string.IsNullOrEmpty(test))
                {
                    // Ako postoji, izbaci ga
                    var lines = File.ReadAllLines(PATH).Where(line => !line.StartsWith(playerName + DEL)).ToList();
                    File.WriteAllLines(PATH, lines);
                }

                File.AppendAllText(PATH, $"{playerName}{DEL}{imagePath}\n");
            }
            catch (Exception)
            {
                throw new Exception("Error with saving player image.");
            }
        }
    }
}
