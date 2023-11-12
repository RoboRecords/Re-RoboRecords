using System.Collections;
using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Leaderboards.Data
{
    public interface IRunRepository
    {
        /// <summary>
        ///  Get all runs
        /// </summary>
        /// <returns>
        /// A collection of all runs
        /// </returns>
        Task<IEnumerable<Run>> GetAllRunsAsync();


        /// <summary>
        ///  Get all runs for a given level
        /// </summary>
        /// <param name="levelId">
        ///  The id of the level to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given level
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByLevelIdAsync(int levelId);

        /// <summary>
        ///  Get all runs for a given character
        /// </summary>
        /// <param name="characterId">
        /// The id of the character to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given character
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByCharacterIdAsync(int characterId);

        /// <summary>
        ///  Get all runs for a given player
        /// </summary>
        /// <param name="playerId">
        /// The id of the player to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given player
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByPlayerIdAsync(string playerId);

        /// <summary>
        ///  Get all runs for a given game
        /// </summary>
        /// <param name="gameId">
        /// The id of the game to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given game
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByGameIdAsync(int gameId);

        /// <summary>
        ///  Get all runs for a given category
        /// </summary>
        /// <param name="categoryId">
        /// The id of the category to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given category
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByCategoryIdAsync(int categoryId);


        /// <summary>
        ///  Get all runs for a given category and level
        /// </summary>
        /// <param name="categoryId">
        /// The id of the category to retrieve runs for
        /// </param>
        /// <param name="levelId">
        /// The id of the level to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given category and level
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByCategoryIdAndLevelIdAsync(int categoryId, int levelId);

        /// <summary>
        /// Get all runs for a given category and character
        /// </summary>
        /// <param name="categoryId">
        /// The id of the category to retrieve runs for
        /// </param>
        /// <param name="playerId">
        /// The id of the player to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given category and player
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByCategoryIdAndPlayerIdAsync(int categoryId, string playerId);

        /// <summary>
        ///  Get all runs for a given category and player
        /// </summary>
        /// <param name="categoryId">
        /// The id of the category to retrieve runs for
        /// </param>
        /// <param name="gameId">
        /// The id of the game to retrieve runs for
        /// </param>
        /// <returns>
        /// A collection of all runs for the given category and game
        /// </returns>
        Task<IEnumerable<Run>> GetRunsByCategoryIdAndGameIdAsync(int categoryId, int gameId);


        /// <summary>
        /// Get a single run by id
        /// </summary>
        /// <param name="runId">
        /// The id of the run to retrieve
        /// </param>
        /// <returns>
        /// The run with the given id
        /// </returns>
        Task<Run> GetRunByIdAsync(int runId);

        /// <summary>
        ///  Add a new run
        /// </summary>
        /// <param name="run">
        /// The run to add
        /// </param>
        /// <returns>
        /// The added run
        /// </returns>
        Task<Run> AddRunAsync(Run run);

        /// <summary>
        /// Update an existing run
        /// </summary>
        /// <param name="run">
        /// The run to update
        /// </param>
        /// <returns>
        /// The updated run
        /// </returns>
        Task<Run> UpdateRunAsync(Run run);

        /// <summary>
        /// Delete a run by id
        /// </summary>
        /// <param name="runId">
        /// The id of the run to delete
        /// </param>
        /// <returns>
        /// The deleted run 
        /// </returns>
        Task<Run> DeleteRunAsync(int runId);
    }
}