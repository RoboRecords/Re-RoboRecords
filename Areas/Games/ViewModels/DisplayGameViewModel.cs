namespace ReRoboRecords.Areas.Games.ViewModels;

public class DisplayGameViewModel
{
    public string GameId { get; set; }
    public string GameName { get; set; }
    
    public string GameAcronym { get; set; }
    public string GameDescription { get; set; }

    public string GameIconUrl { get; set; }

    public int RunCount { get; set; }
}