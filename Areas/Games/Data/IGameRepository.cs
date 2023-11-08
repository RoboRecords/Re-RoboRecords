using System.Collections.Generic;
using System.Threading.Tasks;
using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.Data
{
    public interface IGameRepository
    {
        // Get all games
        Task<IEnumerable<Game>> GetAllGamesAsync();

        // Get a single game by id
        Task<Game> GetGameByIdAsync(int gameId);

        // Add a new game
        Task<Game> AddGameAsync(Game game);

        // Update an existing game
        Task<Game> UpdateGameAsync(Game game);

        // Delete a game by id
        Task DeleteGameAsync(int gameId);
    }
}