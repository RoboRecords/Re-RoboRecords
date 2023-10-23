using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReRoboRecords.Areas.Runs.Controllers
{
    [Area("Runs")]
    public class RunsController : Controller
    {
        private readonly ILogger<RunsController> _logger;

        public RunsController(ILogger<RunsController> logger)
        {
            _logger = logger;
        }
        
    }
}