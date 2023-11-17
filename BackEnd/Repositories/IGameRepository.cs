using BackEnd.Models;

namespace BackEnd.Repositories;

public interface IGameRepository
{
    /// <summary>
    ///  Get all games
    /// </summary>
    /// <returns>
    /// A collection of all games
    /// </returns>
    Task<IEnumerable<Game>> GetAllGamesAsync();

    /// <summary>
    ///  Get a single game by id
    /// </summary>
    /// <param name="gameId">
    ///  The id of the game to retrieve
    /// </param>
    /// <returns>
    ///  The game with the given id
    /// </returns>
    Task<Game> GetGameByIdAsync(int gameId);
        
    /// <summary>
    /// Get a single game by name
    /// </summary>
    /// <param name="gameName">
    /// The name of the game to retrieve
    /// </param>
    /// <returns>
    /// The game with the given name
    /// </returns>
    Task<Game> GetGameByNameAsync(string gameName);

    /// <summary>
    ///  Add a new game
    /// </summary>
    /// <param name="game">
    /// The game to add
    /// </param>
    /// <returns>
    /// The added game
    /// </returns>
    Task<Game> AddGameAsync(Game game);

    /// <summary>
    /// Update an existing game
    /// </summary>
    /// <param name="game">
    /// The game to update
    /// </param>
    /// <returns>
    /// The updated game
    /// </returns>
    Task<Game> UpdateGameAsync(Game game);

    /// <summary>
    /// Delete a game by id
    /// </summary>
    /// <param name="gameId">
    /// The id of the game to delete
    /// </param>
    /// <returns>
    /// The deleted game
    /// </returns>
    Task DeleteGameAsync(int gameId);
}