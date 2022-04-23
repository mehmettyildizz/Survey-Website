using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SurveyApp.Controllers
{
    [Route("[controller]")]
    public class MainPageController : Controller
    {
        
        public IActionResult MainPage()
        {
            return View();
        }

        
    }
}