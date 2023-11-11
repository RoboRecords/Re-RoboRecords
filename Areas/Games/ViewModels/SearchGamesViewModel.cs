using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.ViewModels;

public class SearchGamesViewModel
{
    public List<Game> Games { get; set; }
    
    public string GameName { get; set; }
    
}