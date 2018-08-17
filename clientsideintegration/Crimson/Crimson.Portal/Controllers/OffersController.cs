using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Portal.Data;
using Crimson.Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Portal.Controllers
{
    [Route("partners/{partnerId:int}/[controller]")]
    public class OffersController : Controller
    {
        private readonly CrimsonBackendClient _client;

        public OffersController(CrimsonBackendClient client)
        {
            this._client = client;
        }

        public async Task<IActionResult> Index(int partnerId)
        {
            var offers = await _client.GetOffersAsync(partnerId);
            return View(new OffersOverviewViewModel
            {
                IsEmbedded = Request.Headers.ContainsKey("embedded") ? Convert.ToBoolean(Request.Headers["embedded"]) : false,
                Offers = offers
            });
        }
    }
}