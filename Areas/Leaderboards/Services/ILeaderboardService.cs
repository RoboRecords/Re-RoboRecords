using ReRoboRecords.Areas.Leaderboards.ViewModels;

namespace ReRoboRecords.Areas.Leaderboards.Services;

public interface ILeaderboardService
{
    /// <summary>
    /// Asynchronously gets the leaderboard view model for a specific game.
    /// </summary>
    /// <param name="gameName">The name of the game for which to retrieve leaderboard data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="LeaderboardViewModel"/>.</returns>
    Task<LeaderboardViewModel> GetViewModelAsync(string gameName);
}