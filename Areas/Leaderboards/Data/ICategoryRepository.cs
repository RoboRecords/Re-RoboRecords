using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Leaderboards.Interfaces;

public interface ICategoryRepository
{
    /// <summary>
    /// Get all categories
    /// </summary>
    /// <returns>
    /// A collection of all categories
    /// </returns>
    public Task<IEnumerable<Category>> GetAllCategoriesAsync();


    /// <summary>
    ///  Get a single category by id
    /// </summary>
    /// <param name="categoryId">
    /// The id of the category to retrieve
    /// </param>
    /// <returns>
    /// The category with the given id
    /// </returns>
    public Task<Category> GetCategoryByIdAsync(int categoryId);

    /// <summary>
    ///  Get all categories for a given game
    /// </summary>
    /// <param name="gameId">
    /// The id of the game to retrieve categories for
    /// </param>
    /// <returns>
    /// A collection of all categories for the given game
    /// </returns>
    public Task<IEnumerable<Category>> GetCategoriesByGameIdAsync(int gameId);


    /// <summary>
    ///  Add a new category
    /// </summary>
    /// <param name="category">
    /// The category to add
    /// </param>
    /// <returns>
    /// The added category
    /// </returns>
    public Task<Category> AddCategoryAsync(Category category);

    /// <summary>
    ///  Update an existing category
    /// </summary>
    /// <param name="category">
    /// The category to update
    /// </param>
    /// <returns>
    /// The updated category
    /// </returns>
    public Task<Category> UpdateCategoryAsync(Category category);

    /// <summary>
    ///  Delete a category by id
    /// </summary>
    /// <param name="categoryId">
    /// The id of the category to delete
    /// </param>
    /// <returns>
    /// The deleted category
    /// </returns>
    public Task DeleteCategoryAsync(int categoryId);
}