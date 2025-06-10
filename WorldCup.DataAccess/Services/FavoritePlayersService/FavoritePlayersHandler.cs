using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Enums;
using WorldCup.DataAccess.Helpers;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Services.FavoritePlayersService
{
    internal class FavoritePlayersHandler : IFavoritePlayersHandler
    {
        private static readonly string PATH = SolutionRoot.GetFavoritePlayersPath();
        private readonly char DEL = '#';

        public Task<IEnumerable<Player>> LoadFavoritePlayers()
        {
            try
            {
                var lines = File.ReadAllLines(PATH);
                var players = lines.Select(line =>
                {
                    var parts = line.Split(DEL);
                    return new Player
                    {
                        Name = parts[0],
                        Captain = bool.Parse(parts[1]),
                        ShirtNumber = int.Parse(parts[2]),
                        Position = Enum.Parse<Position>(parts[3])
                    };
                });
                return Task.FromResult(players);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading favorite players. Please check the file path and permissions.", ex);
            }
        }

        public void SaveFavoritePlayers(IEnumerable<Player> players)
        {
            try
            {
                File.WriteAllText(PATH, string.Empty);
                foreach (Player player in players)
                {
                    File.AppendAllText(PATH, $"{player.Name}{DEL}{player.Captain}{DEL}{player.ShirtNumber}{DEL}{player.Position.ToString()}\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving favorite players. Please check the file path and permissions.");
            }
        }
    }
}
