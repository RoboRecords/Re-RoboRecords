namespace ReRoboRecords.Areas.Leaderboards.ViewModels;

public class RunViewModel
{
    public int RunId { get; set; }
    public string CharacterName { get; set; }
    public string Username { get; set; }
    public TimeSpan Time { get; set; }
    public string Comment { get; set; }
    public DateTime DateSubmitted { get; set; }
    public string VideoUrl { get; set; }
}