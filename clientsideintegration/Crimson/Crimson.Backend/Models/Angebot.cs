using System;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Models
{
    public class Angebot
    {
        public int AngebotId { get; set; }
        public int PartnerId { get; set; }
        public string AngebotURI { get; set; }
        public string Sparte { get; set; }
        public string Rolle { get; set; }
        public string Agentur { get; set; }
        public string Versichertist { get; set; }
        public int Schaeden { get; set; }
        public string Ablauf { get; set; }
        public string Zahlungsweise { get; set; }
        public int BeitragZent { get; set; }
        public Fahrzeugdaten Fahrzeugdaten { get; set; }
        public Nutzung Nutzung { get; set; }
        public VersSchutz VersSchutz { get; set; }
    }
}