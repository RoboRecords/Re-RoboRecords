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
    [Route("[area]")] // Sets route as the area name. In this case, /Games.
    public class GamesController : Controller
    {
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Returns the index view for the Games area.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}