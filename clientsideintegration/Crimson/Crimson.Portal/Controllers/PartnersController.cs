using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Portal.Data;
using Crimson.Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Portal.Controllers
{
    [Route("[controller]")]
    public class PartnersController : Controller
    {
        private readonly CrimsonBackendClient _client;

        public PartnersController(CrimsonBackendClient client)
        {
            this._client = client;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var housHolds = await _client.GetHousholdsAsync(id);
            var contracts = await _client.GetContractsAsync(id);
            var partner = await _client.GetPartnerAsync(id);
            var proposals = await _client.GetProposalsAsync(id);
            var offers = await _client.GetOffersAsync(id);
            var contacts = await _client.GetContactsAsync(id);

            var viewModel = new PartnerOverviewViewModel();
            viewModel.Title = $"{partner.Firstname} {partner.Name} - Deckblatt";
            viewModel.Branches = _client.GetBranches(contracts);
            viewModel.Housholds = housHolds;
            viewModel.Contracts = contracts;
            viewModel.Partner = partner;
            viewModel.Contacts = contacts;
            viewModel.Proposals = proposals;
            viewModel.Offers = offers;

            ViewBag.Partner = partner;
            ViewBag.PartnerId = id;
            return View(viewModel);
        }
    }
}