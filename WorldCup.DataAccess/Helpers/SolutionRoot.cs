using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Helpers
{
    public static class SolutionRoot
    {
        public static string GetSettingsPath()
        {
            try
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup", "Assets", "Settings");
                Directory.CreateDirectory(folder);
                return Path.Combine(folder, "Appsettings.txt");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for Appsettings.txt");
            }
        }
        public static string GetFavoritePlayersPath()
        {
            try
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup", "Assets", "FavoritePlayers");
                Directory.CreateDirectory(folder);
                return Path.Combine(folder, "FavoritePlayers.txt");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for FavoritePlayers.txt");
            }
        }
        public static string GetFavoriteNationalTeamPath()
        {
            try
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup", "Assets", "FavoriteNationalTeam");
                Directory.CreateDirectory(folder);
                return Path.Combine(folder, "FavoriteNationalTeam.txt");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for FavoriteNationalTeam.txt");
            }
        }
        public static string GetPlayerImagePath()
        {
            try
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorldCup", "Assets", "PlayerImages");
                Directory.CreateDirectory(folder);
                return Path.Combine(folder, "PlayerImages.txt");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
    }
}
