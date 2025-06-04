using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Helpers;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories.Interfaces;
using WorldCup.DataAccess.Services.AppSettingsService;

namespace WorldCup.DataAccess.Repositories.FileData
{
    public class FileRepository : Interfaces.IDataReader
    {
        private static readonly string TEAMS = SolutionRoot.GetTeamsJsonPath();
        private static readonly string ALL_RESULTS = SolutionRoot.GetAllResultJsonPath();
        private static readonly string GROUP_RESULTS = SolutionRoot.GetGroupResultJsonPath();
        private static readonly string MATCHES = SolutionRoot.GetMatchesJsonPath();

        public FileRepository()
        {
        }

        public Task<List<Match>> GetAllMatchesAsync(string gender)
        {
            if (!File.Exists(MATCHES))
                return Task.FromResult(new List<Match>());

            try
            {
                var json = File.ReadAllText(MATCHES);
                var matches = JsonConvert.DeserializeObject<List<Match>>(json);
                return Task.FromResult(matches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Match>> GetCountryMatchesAsync(string gender, string fifaCode)
        {
            try
            {
                var allMatches = await GetAllMatchesAsync(gender);

                var countryMatches = allMatches
                    .Where(m => m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode)
                    .ToList();

                return countryMatches;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<NationalTeam>> GetTeamsAsync(string gender)
        {
            if (!File.Exists(ALL_RESULTS))
                return Task.FromResult(new List<NationalTeam>());

            try
            {
                var json = File.ReadAllText(ALL_RESULTS);
                var teams = JsonConvert.DeserializeObject<List<NationalTeam>>(json);
                return Task.FromResult(teams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
