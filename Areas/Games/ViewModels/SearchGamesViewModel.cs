using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.ViewModels;

public class SearchGamesViewModel
{
    public SearchGamesViewModel(List<DisplayGameViewModel>? games, string? searchQuery)
    {
        Games = games;
        SearchQuery = searchQuery;
    }

    public List<DisplayGameViewModel> Games { get; set; }
    
    public string SearchQuery { get; set; }
    
}