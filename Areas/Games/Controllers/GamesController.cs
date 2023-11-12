using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GamesController(ILogger<GamesController> logger, IWebHostEnvironment hostingEnvironment,
            IGameRepository gameRepository, IMapper mapper)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns the view for the Games Index page.
        /// </summary>
        [Route("~/[area]")]
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGamesAsync().Result.ToList();
            var model = new SearchGamesViewModel(_mapper.Map(games, new List<DisplayGameViewModel>()), "");
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
                if (_gameRepository.GetAllGamesAsync().Result.Any(g => g.GameName == model.GameName))
                {
                    ModelState.AddModelError("Name", "A game with this name already exists.");
                    return View(model);
                }
                
                // Check if the game acronym already exists
                if (_gameRepository.GetAllGamesAsync().Result.Any(g => g.GameAcronym == model.GameAcronym))
                {
                    ModelState.AddModelError("Name", "A game with this acronym already exists.");
                    return View(model);
                }

                string imagePath = null;
                // Check if the game image is not null
                if (model.GameImage is { Length: > 0 })
                {
                    var fileName = Guid.NewGuid() + "-" + model.GameImage.FileName;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
                    imagePath = "uploads/" + fileName;
                    // Copy the file to the uploads folder
                    await using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.GameImage.CopyToAsync(stream);
                    }
                }
                
                
                var game = new Game
                {
                    GameName = model.GameName,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate,
                    GameVersion = model.GameVersion,
                    GameAcronym = model.GameAcronym,
                    GameImagePath = imagePath
                };

                await _gameRepository.AddGameAsync(game);

                return RedirectToAction("Index"); // Goes back to index view if successful.
            }

            return View(model);
        }
    }
}