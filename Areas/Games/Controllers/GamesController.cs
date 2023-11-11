using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReRoboRecords.Areas.Games.Data;
using ReRoboRecords.Areas.Games.Models;
using ReRoboRecords.Areas.Games.ViewModels;

namespace ReRoboRecords.Areas.Games.Controllers
{
    [Area("Games")]
    [Route("[area]/[action]")] // Sets route as the area name. In this case, /Games.
    public class GamesController : Controller
    {
        private readonly ILogger<GamesController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IGameRepository _gameRepository;

        public GamesController(ILogger<GamesController> logger, IWebHostEnvironment hostingEnvironment, IGameRepository gameRepository)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _gameRepository = gameRepository;
        }
    
        /// <summary>
        /// Returns the view for the Games Index page.
        /// </summary>
        [Route("~/[area]")]
        public IActionResult Index()
        {
            var model = new SearchGamesViewModel
            {
                Games = _gameRepository.GetAllGamesAsync().Result.ToList()
            };
            return View(model); // Returns the Index view.   
        }
        
        
        /// <summary>
        /// Returns the view for the New Game page.
        /// </summary>
        [HttpGet]
        public IActionResult New()
        {
            return View(); // Returns the New view.
        }
        
        [HttpPost]
        public async Task<IActionResult> New(NewGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the game name already exists
                if (_gameRepository.GetAllGamesAsync().Result.Any(g => g.Title == model.Title))
                {
                    ModelState.AddModelError("Name", "A game with this name already exists.");
                    return View(model);
                }
                
                string imagePath = null;
                if (model.GameImage is { Length: > 0 })
                {
                    var fileName = Guid.NewGuid() + "-" + model.GameImage.FileName;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
                    imagePath = "uploads/" + fileName;
                    await using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.GameImage.CopyToAsync(stream);
                    }

                }

                var game = new Game
                {
                    Title = model.Title,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate,
                    GameVersion = model.GameVersion, 
                    GameImagePath = imagePath
                };
                
                await _gameRepository.AddGameAsync(game);
                
                return RedirectToAction("Index"); // Goes back to index view if successful.

            }

            return View(model);
        }
    }
}