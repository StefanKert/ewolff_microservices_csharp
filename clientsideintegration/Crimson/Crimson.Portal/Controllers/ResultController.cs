using Crimson.Portal.Data;
using Crimson.Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Portal.Controllers
{
    public class ResultController : Controller
    {
        private readonly CrimsonBackendClient _client;

        public ResultController(CrimsonBackendClient client)
        {
            this._client = client;
        }

        public async Task<IActionResult> Index([FromQuery]string query)
        {
            var foundPartners = await _client.FindPartnerAsync(query);
            return View(new ResultViewModel {
                Query = query,
                FoundPartners = foundPartners
            });
        }
    }
}
 