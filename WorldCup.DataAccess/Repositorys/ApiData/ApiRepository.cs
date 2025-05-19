using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using RestSharp;

namespace WorldCup.DataAccess.Repositorys.ApiData
{
    public class ApiRepository : IDataReader
    {
        private readonly RestClient _restClient;

        public ApiRepository()
        {
            _restClient = new RestClient("https://worldcup-vua.nullbit.hr/");
        }

        public async Task<List<Team>> GetTeamsAsync(string gender)
        {
            var request = new RestRequest($"{gender}/teams/result", Method.Get);
            var response = await _restClient.ExecuteAsync<List<Team>>(request);
            if (response.IsSuccessful)
            {
                return response.Data ?? new List<Team>();
            }
            else
            {
                throw new Exception($"Error fetching teams: {response.ErrorMessage}");
            }
        }

        public async Task<List<Match>> GetAllMatchesAsync(string gender)
        {
            var request = new RestRequest($"{gender}/matches", Method.Get);
            var response = await _restClient.ExecuteAsync<List<Match>>(request);
            if (response.IsSuccessful)
            {
                return response.Data ?? new List<Match>();
            }
            else
            {
                throw new Exception($"Error fetching matches: {response.ErrorMessage}");
            }
        }

        public async Task<List<Match>> GetCountryMatchesAsync(string gender, string fifaCode)
        {
            var request = new RestRequest($"{gender}/matches/country?fifa_code={fifaCode}", Method.Get);
            var response = await _restClient.ExecuteAsync<List<Match>>(request);
            if (response.IsSuccessful)
            {
                return response.Data ?? new List<Match>();
            }
            else
            {
                throw new Exception($"Error fetching matches: {response.ErrorMessage}");
            }
        }
    }

}
