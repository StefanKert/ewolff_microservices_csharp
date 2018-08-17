using Crimson.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Portal.ViewModels
{
    public class ResultViewModel
    {
        public string Query { get; set; }
        public IEnumerable<SimplifiedPartner> FoundPartners { get; set; }
    }
}
