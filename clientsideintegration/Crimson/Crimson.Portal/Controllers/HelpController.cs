using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Portal.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Example()
        {
            return View();
        }

        public IActionResult Shortcuts()
        {
            return View();
        }
    }
}