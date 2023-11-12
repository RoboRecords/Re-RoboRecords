using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Leaderboards.Data
{
    public interface ICharacterRepository
    {
        /// <summary>
        ///   Get all characters
        /// </summary>
        /// <returns>
        ///  A collection of all characters
        /// </returns>
        Task<IEnumerable<Character>> GetAllCharactersAsync();

        /// <summary>
        ///  Get a single character by id
        /// </summary>
        /// <param name="characterId">
        ///  The id of the character to retrieve
        /// </param>
        /// <returns>
        /// The character with the given id
        /// </returns>
        Task<Character> GetCharacterByIdAsync(int characterId);

        /// <summary>
        ///  Get a single character by name
        /// </summary>
        /// <param name="character">
        ///  The name of the character to retrieve
        /// </param>
        /// <returns>
        ///  The character with the given name
        /// </returns>
        Task<Character> AddCharacterAsync(Character character);

        /// <summary>
        ///  Update an existing character
        /// </summary>
        /// <param name="character">
        /// The character to update
        /// </param>
        /// <returns>
        /// The updated character
        /// </returns>
        Task<Character> UpdateCharacterAsync(Character character);

        /// <summary>
        /// Delete a character by id
        /// </summary>
        /// <param name="characterId">
        /// The id of the character to delete
        /// </param>
        /// <returns>
        /// The deleted character
        /// </returns>
        Task DeleteCharacterAsync(int characterId);
    }
}