using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Portal.Models
{
    public class Branch
    {
        public string Label { get; set; }
        public string ClassName { get; set; }
        public string Icon { get; set; }
        public int NumberOfContracts { get; set; }


        public static List<Branch> Branches = new List<Branch>
        {
            new Branch { Label= "Fonds", ClassName= "fonds" },
            new Branch { Label= "Finanzen", ClassName= "finanzen" },
            new Branch { Label= "Leben", ClassName= "leben" },
            new Branch { Label= "Kranken", ClassName= "kranken" },
            new Branch  { Label= "Unfall", ClassName= "unfall" },
            new Branch  { Label= "Haftpflicht", ClassName= "haftpflicht" },
            new Branch  { Label= "Sach", ClassName= "sach" },
            new Branch  { Label= "Recht", ClassName= "recht" },
            new Branch { Label= "Kraftfahrt", ClassName= "kfz", Icon = "icon-car-2-filled" }
        };
    }
}
