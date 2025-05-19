using System.Numerics;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Repositorys.Interfaces
{
    public interface IDataReader
    {
        Task<List<Team>> GetTeamsAsync(string gender);
        Task<List<Match>> GetAllMatchesAsync(string gender);
        Task<List<Match>> GetCountryMatchesAsync(string gender, string fifaCode);

    }
}