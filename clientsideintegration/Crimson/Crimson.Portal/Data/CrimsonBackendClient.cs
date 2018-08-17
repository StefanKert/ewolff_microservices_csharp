using Crimson.Portal.Contracts.Backend;
using Crimson.Portal.Extensions;
using Crimson.Portal.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Partner = Crimson.Portal.Models.Partner;

namespace Crimson.Portal.Data
{
    public class CrimsonBackendClient
    {
        private HttpClient _client;
        private ILogger<CrimsonBackendClient> _logger;

        public CrimsonBackendClient(HttpClient client, ILogger<CrimsonBackendClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<Houshold>> GetHousholdsAsync(int partnerId)
        {
            var url = new Uri($"/partners/{partnerId}/haushalt", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendHaushalt = await res.Content.ReadAsAsync<List<Haushalt>>();

            return backendHaushalt.Select(x => new Houshold
            {
                Name = $"{x.Vorname} {x.Name}",
                Dob = x.Geburtsdatum,
                Relationship = x.Beziehung
            });
        }

        public async Task<IEnumerable<Contract>> GetContractsAsync(int partnerId)
        {
            var url = new Uri($"/vertraege?partnerId={partnerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendVertraege = await res.Content.ReadAsAsync<List<Vertrag>>();
            return backendVertraege.Select(x =>
                new Contract
                {
                    Id = x.Vsnr,
                    Branch = x.Sparte,
                    Fee = x.BeitragZent,
                    FormattedFee = x.BeitragZent.ToString("C"),
                    Icon = Branch.Branches.FirstOrDefault(b => b.Label == x.Sparte)?.Icon,
                    ContractUri = $"/partners/{x.PartnerId}/contracts/{x.Vsnr}"
                });
        }

        public async Task<IEnumerable<Proposal>> GetProposalsAsync(int partnerId)
        {
            var url = new Uri($"/antraege?partnerId={partnerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<List<Antrag>>();
            return backendData.Select(x =>
                new Proposal
                {
                    Branch = x.Sparte,
                    Fee = x.BeitragZent,
                    FormattedFee = x.BeitragZent.ToString("C"),
                    Icon = Branch.Branches.FirstOrDefault(b => b.Label == x.Sparte)?.Icon,
                    //Uri = x.AntragUri This URI is never set in the backend : TODO
                });
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(int partnerId)
        {
            var url = new Uri($"/angebote?partnerId={partnerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<List<Angebot>>();
            return backendData.Select(x =>
                new Offer
                {
                    Id = x.AngebotId,
                    Agency = x.Agentur,
                    Branch = x.Sparte,
                    Claims = x.Schaeden,
                    Expire = x.Ablauf,
                    Fee = x.BeitragZent,
                    FormattedFee = x.BeitragZent.ToString("C"),
                    Icon = Branch.Branches.FirstOrDefault(b => b.Label == x.Sparte)?.Icon,
                    Incident = x.Versichertist,
                    PaymentInterval = x.Zahlungsweise,
                    Role = x.Rolle,
                    OfferUri = $"/partners/{x.PartnerId}/offers/{x.AngebotId}"
                });
        }

        public async Task<Offer> GetOfferAsync(int offerId)
        {
            var url = new Uri($"/angebot/{offerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<Angebot>();
            return backendData.ToOffer();
        }

        public async Task<Offer> CopyOfferAsync(int offerId)
        {
            var url = new Uri($"/angebot/{offerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.PostAsync(url, null);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<Angebot>();
            return backendData.ToOffer();
        }

        public async Task<Offer> CreateOfferAsync(int offerId, Offer offer)
        {
            var url = new Uri($"/angebot", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.PostAsJsonAsync(url, offer);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<Angebot>();
            return backendData.ToOffer();
        }

        public async Task<List<object>> OfferAllocationAsync(int partnerId)
        {
            var url = new Uri($"/angebot/kraftfahrt/vorbelegung?partnerId={partnerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsAsync<List<object>>();
        }

        public async Task<List<object>> OfferCalculationAsync(int offerId, object offer)
        {
            var url = new Uri($"/angebot/kraftfahrt/berechnen", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.PostAsJsonAsync(url, offer);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsAsync<List<object>>();
        }

        public async Task<IEnumerable<SimplifiedPartner>> FindPartnerAsync(string query)
        {
            var url = new Uri($"/partners?q={query}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<List<Contracts.Backend.Partner>>();
            return backendData.Select(x => x.ToSimplifiedPartner());
        }

        public async Task<Partner> GetPartnerAsync(int partnerId)
        {
            var url = new Uri($"/partners/{partnerId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<Contracts.Backend.Partner>();
            return backendData.ToPartner();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(int partnerId)
        {
            var url = new Uri($"/partners/{partnerId}/kontakt", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            res.EnsureSuccessStatusCode();
            var backendData = await res.Content.ReadAsAsync<List<Contracts.Backend.Kontakthistorie>>();
            return backendData.Select(x => x.ToContact());
        }

        public async Task<List<object>> GetContractAsync(int contractId)
        {
            var url = new Uri($"/vertrag/{contractId}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsAsync<List<object>>();
        }

        public async Task<List<object>> GetJobsAsync(string query)
        {
            var url = new Uri($"/berufe?q={query}", UriKind.Relative);
            _logger.LogWarning($"HttpClient: Loading {url}");
            var res = await _client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsAsync<List<object>>();
        }

        public IEnumerable<Branch> GetBranches(IEnumerable<Contract> contracts)
        {
            return Branch.Branches.Select(x =>
            {
                x.NumberOfContracts = contracts.Count(c => c.Branch == x.Label);
                return x;
            });
        }
    }
}