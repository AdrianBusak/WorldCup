using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Services.AppSettingsService
{
    public class AppSettingsHandler : IAppSettingsHandler
    {
        private const string FilePath = "settings/appsettings.txt";


        public void SaveSettings(Models.AppSettings settings)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                File.WriteAllLines(FilePath, new[]
                {
                $"language={settings.Language}",
                $"competition={settings.Competition}",
                $"dataSource={settings.DataSource}"
            });
            }
            catch (Exception)
            {
                throw new Exception("Error saving settings. Please check the file path and permissions.");
            }
        }

        public Models.AppSettings LoadSettings()
        {
            if (!File.Exists(FilePath))
                return new Models.AppSettings()
                {
                    Competition = "man",
                    Language = "hr",
                    DataSource = "API",
                };

            try
            {
                var lines = File.ReadAllLines(FilePath);
                var dict = lines.Select(line => line.Split('=')).ToDictionary(p => p[0], p => p[1]);

                return new Models.AppSettings()
                {
                    Language = dict.GetValueOrDefault("language", "hr"),
                    Competition = dict.GetValueOrDefault("competition", "men"),
                    DataSource = dict.GetValueOrDefault("dataSource", "API")
                };
            }
            catch (Exception)
            {
                throw new Exception("Error with parsing settings. Please check it.");
            }

        }
    }
}
