using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
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

        public DataRepository()
        {
            _repo = RepositoryFactory.CreateReader();

            _appSettingsHandler = RepositoryFactory.CreateAppSettingsHandler();
            _playerImageHandler = RepositoryFactory.CreatePlayerImagePathHandler();
            _favoriteTeamHandler = RepositoryFactory.CreateFavoriteTeamHandler();
            _favoritePlayersHandler = RepositoryFactory.CreateFavoritePlayersHandler();
        }

        public Task<List<NationalTeam>> GetTeamsAsync()
        {
            var settings = _appSettingsHandler.LoadSettings();
            return _repo.GetTeamsAsync(settings.Competition);
        }

        public Task<List<Match>> GetAllMatchesAsync()
        {
            var settings = _appSettingsHandler.LoadSettings();
            return _repo.GetAllMatchesAsync(settings.Competition);
        }

        public Task<List<Match>> GetCountryMatchesAsync(string fifaCode)
        {
            var settings = _appSettingsHandler.LoadSettings();
            return _repo.GetCountryMatchesAsync(settings.Competition, fifaCode);
        }

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
                    Position = player.Position
                }).ToList();

            var away = firstMatch.AwayTeamStatistics.StartingEleven
                .Concat(firstMatch.AwayTeamStatistics.Substitutes)
                .Select(player => new Player
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = (int)player.ShirtNumber,
                    Position = player.Position
                }).ToList();

            return firstMatch.HomeTeam.Code == fifaCode
                ? home
                : away;
        }

        public List<StartingEleven> GetPlayersFromMatch(Match match, string country)
        {
            if (match == null) return new List<StartingEleven>();

            var home = match.HomeTeamStatistics.StartingEleven
                .Select(player => new StartingEleven
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = (int)player.ShirtNumber,
                    Position = player.Position
                }).ToList();

            var away = match.AwayTeamStatistics.StartingEleven
                .Select(player => new StartingEleven
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = (int)player.ShirtNumber,
                    Position = player.Position
                }).ToList();

            return match.HomeTeam.Country == country
                ? home
                : away;
        }

        public async Task<Match> GetMatchByTeamsAsync(string homeTeam, string awayTeam)
        {
            var settings = _appSettingsHandler.LoadSettings();
            List<Match> matches = await _repo.GetAllMatchesAsync(settings.Competition);

            return matches.FirstOrDefault(m =>
                (m.HomeTeam.Country == homeTeam && m.AwayTeam.Country == awayTeam) ||
                (m.HomeTeam.Country == awayTeam && m.AwayTeam.Country == homeTeam));
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
