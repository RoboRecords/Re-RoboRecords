using System.Collections;
using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Leaderboards.Data
{
    public interface ILevelRepository
    {
        /// <summary>
        ///  Get all levels
        /// </summary>
        /// <returns>
        /// A collection of all levels
        /// </returns>
        Task<IEnumerable<Level>> GetAllLevelsAsync();

        /// <summary>
        ///  Get all levels for a given game
        /// </summary>
        /// <param name="gameId">
        /// The id of the game to retrieve levels for
        /// </param>
        /// <returns>
        /// A collection of all levels for the given game
        /// </returns>
        Task<IEnumerable<Level>> GetLevelsByGameIdAsync(int gameId);

        /// <summary>
        /// Get a single level by id
        /// </summary>
        /// <param name="levelId">
        /// The id of the level to retrieve
        /// </param>
        /// <returns>
        /// The level with the given id
        /// </returns>
        Task<Level> GetLevelByIdAsync(int levelId);

        /// <summary>
        ///  Add a new level
        /// </summary>
        /// <param name="level">
        /// The level to add
        /// </param>
        /// <returns>
        /// The added level
        /// </returns>
        Task<Level> AddLevelAsync(Level level);

        /// <summary>
        ///  Update an existing level
        /// </summary>
        /// <param name="level">
        /// The level to update
        /// </param>
        /// <returns>
        /// The updated level
        /// </returns>
        Task<Level> UpdateLevelAsync(Level level);

        /// <summary>
        ///  Delete a level by id
        /// </summary>
        /// <param name="levelId">
        /// The id of the level to delete
        /// </param>
        /// <returns>
        /// The deleted level
        /// </returns>
        Task DeleteLevelAsync(int levelId);
    }
}