using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Leaderboards.ViewModels;

public class LeaderboardViewModel
{
    public string GameName { get; set; }
    public List<RunViewModel> Runs { get; set; }
    public List<CategoryViewModel> Categories { get; set; }

    // Constructor
    public LeaderboardViewModel()
    {
        Runs = new List<RunViewModel>();
        Categories = new List<CategoryViewModel>();
    }
}