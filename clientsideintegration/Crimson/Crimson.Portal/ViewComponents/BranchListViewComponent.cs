using Crimson.Portal.Data;
using Crimson.Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Portal.ViewComponents
{
    public class BranchListViewComponent : ViewComponent
    {
        private readonly CrimsonBackendClient _client;

        public BranchListViewComponent(CrimsonBackendClient client)
        {
            this._client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync(int partnerId)
        {
            var partner = await _client.GetPartnerAsync(partnerId);
            var contracts = await _client.GetContractsAsync(partnerId);
            var branches = _client.GetBranches(contracts);

            var viewModel = new BranchListViewModel
            {
                Partner = partner,
                Branches = branches
            };
            return View(viewModel);
        }
    }
}
