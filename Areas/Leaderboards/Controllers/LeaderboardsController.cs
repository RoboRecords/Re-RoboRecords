using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Games.Data;
using ReRoboRecords.Areas.Leaderboards.Services;
using ReRoboRecords.Areas.Leaderboards.ViewModels;

namespace ReRoboRecords.Areas.Leaderboards.Controllers;

[Area("Leaderboards")]
[Route("[area]/[action]")] 
public class LeaderboardsController : Controller
{
    private readonly ILogger<LeaderboardsController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ILeaderboardService _leaderboardService;
    
    public LeaderboardsController(ILogger<LeaderboardsController> logger, IWebHostEnvironment hostingEnvironment, IGameRepository gameRepository, ILeaderboardService leaderboardService)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
        _leaderboardService = leaderboardService;
    }
    
    public IActionResult Index(string? gameAcronym)
    {

        if (String.IsNullOrEmpty(gameAcronym))
        {
            return RedirectToAction("Index", "Games", new {area = "Games"});
        }
        
        var model = _leaderboardService.GetViewModelAsync(gameAcronym).Result;
        return View(model);
    }
    
    // Get all runs for a specific game
    public async Task<JsonResult> GetAllRunsForGame(string gameName)
    {
        try
        {
            // Fetch the runs from the game service
            var runs = await _leaderboardService.GetAllRunsForGameAsync(gameName);
            
            var runViewModels = runs.Select(run => new RunViewModel
            {
                RunId = run.RunId,
                Username = run.Username,
                Time = run.Time,
                CharacterName = run.Character.Name, // Assuming you have related data loaded
                DateSubmitted = run.DateSubmitted,
                VideoUrl = run.VideoUrl,
                // ... other properties as needed
            }).ToList();

            return Json(runViewModels);
        }
        catch (Exception ex)
        {
            return Json(new { error = $"An error occurred getting runs for {gameName}",gameName });
        }
    }

}