using Crimson.Portal.Contracts.Backend;
using System.Collections.Generic;

namespace Crimson.Portal.Contracts.Backend
{
    public class Vertrag
    {
        public int Vsnr { get; set; }
        public int PartnerId { get; set; }
        public string Sparte { get; set; }
        public int BeitragZent { get; set; }
        public string VertragURI { get; set; }
        public Fahrzeugdaten Fahrzeugdaten { get; set; }
        public List<Schaden> Vorschaeden { get; set; }
        public List<Versicherer> Vorversicherer { get; set; }
        public Nutzung Nutzung { get; set; }
        public VersSchutz VersSchutz { get; set; }    
    }
}
