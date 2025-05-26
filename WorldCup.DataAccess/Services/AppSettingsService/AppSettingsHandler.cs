using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Helpers;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Services.AppSettingsService
{
    public class AppSettingsHandler : IAppSettingsHandler
    {
        private static readonly string FILEPATH = SolutionRoot.GetSettingsPath();
        public void SaveSettings(AppSettings settings)
        {
            try
            {
                if (settings == null)
                    throw new ArgumentNullException(nameof(settings), "AppSettings object is null.");

                var directory = Path.GetDirectoryName(FILEPATH);
                if (string.IsNullOrWhiteSpace(directory))
                    throw new Exception("Settings directory path is invalid.");

                Directory.CreateDirectory(directory);

                if (!File.Exists(FILEPATH))
                {
                    using (File.Create(FILEPATH)) { }
                    ;
                }

                File.WriteAllLines(FILEPATH, new[]
                {
                    $"language={settings.Language.ToLower()}",
                    $"competition={settings.Competition.ToLower()}",
                    $"dataSource={settings.DataSource.ToLower()}"
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save app settings: " + ex.Message);
            }
        }



        public Models.AppSettings LoadSettings()
        {
            if (!File.Exists(FILEPATH))
                return new Models.AppSettings()
                {
                    Competition = "men",
                    Language = "hr",
                    DataSource = "api",
                };

            try
            {
                var lines = File.ReadAllLines(FILEPATH);
                var dict = lines.Select(line =>
                line.Split('='))
                    .ToDictionary(p => p[0].Trim(), p => p[1].Trim());

                return new Models.AppSettings()
                {
                    Language = dict.GetValueOrDefault("language", "hr"),
                    Competition = dict.GetValueOrDefault("competition", "men"),
                    DataSource = dict.GetValueOrDefault("dataSource", "api")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
