using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositorys.Interfaces;
using WorldCup.DataAccess.Services.AppSettingsService;

namespace WorldCup.DataAccess.Repositorys.FileData
{
    public class FileRepository : Interfaces.IDataReader
    {
        private const string BASEPATH = @"\assets\worldcup";
        private static string RESULTS = @"\results.json";
        private static string TEAMS = @"\teams.json";
        private static string MATCHES = @"\matches.json";

        public FileRepository()
        {
        }

        public Task<List<Match>> GetAllMatchesAsync(string gender)
        {
            var path = Path.Combine(BASEPATH, @$"\{gender}{MATCHES}");
            if (!File.Exists(path))
                return Task.FromResult(new List<Match>());

            var json = File.ReadAllText(path);
            var matches = JsonConvert.DeserializeObject<List<Match>>(json);
            return Task.FromResult(matches);
        }

        public async Task<List<Match>> GetCountryMatchesAsync(string gender, string fifaCode)
        {
            var allMatches = await GetAllMatchesAsync(gender);

            var countryMatches = allMatches.Where(m => m.HomeTeamCountry == fifaCode || m.AwayTeamCountry == fifaCode).ToList();
            
            return countryMatches;
        }

        public Task<List<Team>> GetTeamsAsync(string gender)
        {
            var path = Path.Combine(BASEPATH, @$"\{gender}{TEAMS}");
            if (!File.Exists(path))
                return Task.FromResult(new List<Team>());

            var json = File.ReadAllText(path);
            var teams = JsonConvert.DeserializeObject<List<Team>>(json);
            return Task.FromResult(teams);
        }

    }
}
