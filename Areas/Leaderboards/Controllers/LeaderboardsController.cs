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
        
        var model = _leaderboardService.GetViewModelAsync(gameAcronym);
        return View(model);
    }
}