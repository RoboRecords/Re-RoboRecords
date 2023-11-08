using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReRoboRecords.Areas.Games.Controllers
{
    [Area("Games")]
    [Route("[area]/[action]")] // Sets route as the area name. In this case, /Games.
    public class GamesController : Controller
    {
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }
    
        /// <summary>
        /// Returns the view for the Games Index page.
        /// </summary>
        [Route("~/[area]")]
        public IActionResult Index()
        {
            return View(); // Returns the Index view.   
        }
        
        
        /// <summary>
        /// Returns the view for the New Game page.
        /// </summary>
        [HttpGet]
        public IActionResult New()
        {
            return View(); // Returns the New view.
        }
    }
}