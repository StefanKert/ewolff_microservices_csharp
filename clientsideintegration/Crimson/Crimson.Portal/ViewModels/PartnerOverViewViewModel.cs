using Crimson.Portal.Models;
using System.Collections.Generic;

namespace Crimson.Portal.ViewModels
{
    public class PartnerOverviewViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Houshold> Housholds { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
        public Partner Partner { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Proposal> Proposals { get; set; }
        public IEnumerable<Offer> Offers { get; set; }

    }
}
