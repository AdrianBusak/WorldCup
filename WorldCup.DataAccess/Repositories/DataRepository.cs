using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;
using WorldCup.DataAccess.Services;
using WorldCup.DataAccess.Services.AppSettingsService;
using WorldCup.DataAccess.Services.FavoritePlayersService;
using WorldCup.DataAccess.Services.FavoriteTeamService;
using WorldCup.DataAccess.Services.PlayerImagePathService;

namespace WorldCup.DataAccess.Repositories
{
    public class DataRepository
    {
        private readonly Interfaces.IDataReader _repo;

        private readonly IAppSettingsHandler _appSettingsHandler;
        private readonly IPlayerImagePathHandler _playerImageHandler;
        private readonly IFavoriteTeamHandler _favoriteTeamHandler;
        private readonly IFavoritePlayersHandler _favoritePlayersHandler;

        private static AppSettings appSettings;
        public DataRepository()
        {
            _repo = RepositoryFactory.CreateReader();

            _appSettingsHandler = RepositoryFactory.CreateAppSettingsHandler();
            _playerImageHandler = RepositoryFactory.CreatePlayerImagePathHandler();
            _favoriteTeamHandler = RepositoryFactory.CreateFavoriteTeamHandler();
            _favoritePlayersHandler = RepositoryFactory.CreateFavoritePlayersHandler();

            appSettings = _appSettingsHandler.LoadSettings();
        }

        public Task<List<NationalTeam>> GetTeamsAsync()
           => _repo.GetTeamsAsync(appSettings.Competition);

        public Task<List<Match>> GetAllMatchesAsync()
            => _repo.GetAllMatchesAsync(appSettings.Competition);

        public Task<List<Match>> GetCountryMatchesAsync(string fifaCode)
            => _repo.GetCountryMatchesAsync(appSettings.Competition, fifaCode);

        public async Task<List<Player>> GetPlayersFromFirstMatchAsync(string fifaCode)
        {
            var matches = await GetCountryMatchesAsync(fifaCode);
            var firstMatch = matches.Count > 0 ? matches[0] : null;
            if (firstMatch == null) return new List<Player>();

            var home = firstMatch.HomeTeamStatistics.StartingEleven
                .Concat(firstMatch.HomeTeamStatistics.Substitutes)
                .Select(player => new Player
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = (int)player.ShirtNumber,
                    Position = player.Position.ToString()
                }).ToList();

            var away = firstMatch.AwayTeamStatistics.StartingEleven
                .Concat(firstMatch.AwayTeamStatistics.Substitutes)
                .Select(player => new Player
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = (int)player.ShirtNumber,
                    Position = player.Position.ToString()
                }).ToList();

            return firstMatch.HomeTeam.Code == fifaCode
                ? home
                : away;
        }

        //
        // ———  LOCAL SETTINGS & FAVORITES  ———
        //

        public AppSettings LoadSettings()
            => _appSettingsHandler.LoadSettings();

        public void SaveSettings(AppSettings settings)
            => _appSettingsHandler.SaveSettings(settings);

        public string LoadFavoriteTeam()
            => _favoriteTeamHandler.LoadFavoriteTeam();

        public void SaveFavoriteTeam(string fifaCode)
            => _favoriteTeamHandler.SaveFavoriteTeam(fifaCode);

        public async Task<IEnumerable<Player>> LoadFavoritePlayers()
            => await _favoritePlayersHandler.LoadFavoritePlayers();

        public void SaveFavoritePlayers(IEnumerable<Player> players)
            => _favoritePlayersHandler.SaveFavoritePlayers(players);

        //
        // ———  PLAYER IMAGE PATHS  ———
        //

        public string LoadPlayerImagePath(string playerName)
            => _playerImageHandler.LoadImage(playerName);

        public void SavePlayerImage(string imagePath, string playerName)
            => _playerImageHandler.SaveImage(imagePath, playerName);

    }
}