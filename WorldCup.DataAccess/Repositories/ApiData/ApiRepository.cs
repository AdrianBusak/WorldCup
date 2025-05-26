using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace WorldCup.DataAccess.Repositories.ApiData
{
    public class ApiRepository : IDataReader
    {
        private readonly RestClient _restClient;

        public ApiRepository()
        {
            var options = new RestClientOptions("https://worldcup-vua.nullbit.hr/")
            {
                ThrowOnAnyError = true,
            };
            _restClient = new RestClient(
                    options,
                    configureSerialization: s => s.UseNewtonsoftJson()
                    );
        }

        public async Task<List<NationalTeam>> GetTeamsAsync(string gender)
        {
            var request = new RestRequest($"{gender}/teams/results", Method.Get);
            var response = await _restClient.ExecuteAsync<List<NationalTeam>>(request);
            if (response.IsSuccessful)
            {
                return response.Data ?? new List<NationalTeam>();
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
            try
            {
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
            catch (Exception)
            {

                throw new Exception("Bad request. Include the existing country fifa code!");
            }
        }
    }
}
