using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Services.AppSettingsService;

namespace WorldCup.DataAccess.Helpers
{
    public static class SolutionRoot
    {
        private static IAppSettingsHandler appSettingsHandler = new AppSettingsHandler();
        private static readonly AppSettings settings = appSettingsHandler.LoadSettings();
        public static string GetSettingsPath()
        {
            try
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WorldCup", "Assets", "Settings");
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
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WorldCup", "Assets", "FavoritePlayers");
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
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WorldCup", "Assets", "FavoriteNationalTeam");
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
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WorldCup", "Assets", "PlayerImages");
                Directory.CreateDirectory(folder);
                return Path.Combine(folder, "PlayerImages.txt");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
        public static string GetMatchesJsonPath()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(baseDir, "AssetsJson", "worldcup", settings.Competition, "matches.json");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
        public static string GetTeamsJsonPath()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(baseDir, "AssetsJson", "worldcup", settings.Competition, "teams.json");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
        public static string GetAllResultJsonPath()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(baseDir, "AssetsJson", "worldcup", settings.Competition, "results.json");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
        public static string GetGroupResultJsonPath()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(baseDir, "AssetsJson", "worldcup", settings.Competition, "group_results.json");
            }
            catch (Exception)
            {

                throw new Exception("Error with creating folder for PlayerImages.txt");
            }
        }
    }
}
