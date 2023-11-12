using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Games.Data;
using ReRoboRecords.Areas.Leaderboards.ViewModels;

namespace ReRoboRecords.Areas.Leaderboards.Controllers;

[Area("Leaderboards")]
[Route("[area]/[action]")] 
public class LeaderboardsController : Controller
{
    private readonly ILogger<LeaderboardsController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IGameRepository _gameRepository;
    
    public LeaderboardsController(ILogger<LeaderboardsController> logger, IWebHostEnvironment hostingEnvironment, IGameRepository gameRepository)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
        _gameRepository = gameRepository;
    }
    
    public IActionResult Index(string gameName)
    {
        var model = new LeaderboardViewModel()
        {
        };
        return View();
    }
}