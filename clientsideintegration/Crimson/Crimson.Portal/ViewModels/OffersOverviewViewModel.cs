using Crimson.Portal.Models;
using System.Collections.Generic;

namespace Crimson.Portal.ViewModels
{
    public class OffersOverviewViewModel {
        public bool IsEmbedded { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
