using Crimson.Portal.Models;
using System.Collections.Generic;

namespace Crimson.Portal.ViewModels
{
    public class BranchListViewModel
    {
        public Partner Partner { get; set; }
        public IEnumerable<Branch> Branches  { get; set; }
    }
}
