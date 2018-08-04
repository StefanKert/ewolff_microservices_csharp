namespace Crimson.Backend.Models
{
               antragId: antragId,
            partnerId: 4711 + (currentId % 15),
            sparte: 'Kraftfahrt',
beitragZent: Math.floor(Math.random() * 40000 + 2000)
    public class Antrag
    {
        public int AntragId { get; set; }
        public int PartnerId { get; set; }
        public string Sparte { get; set; }
        public double BeitragZent { get; set; }
    }
}
