using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Helpers
{
    public static class SolutionRoot
    {
        public static string GetSettingsPath()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup", "Assets", "Settings");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "Appsettings.txt");
        }
        public static string GetFavoritePlayersPath()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup","Assets", "Settings");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "FavoritePlayers.txt");
        }
        public static string GetFavoriteNationalTeamPath()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup","Assets", "Settings");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "FavoriteNationalTeam.txt");
        }
    }
}
