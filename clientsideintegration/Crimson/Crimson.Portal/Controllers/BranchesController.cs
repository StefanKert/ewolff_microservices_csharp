using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Portal.Controllers
{
    [Route("partners/{id}/[controller]")]
    public class BranchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}