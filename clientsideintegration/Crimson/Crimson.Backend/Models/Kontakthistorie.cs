namespace Crimson.Backend.Models
{
    public class Kontakthistorie
    {
        public int PartnerId { get; set; }
        public string Kontaktart { get; set; }
        public string Zeit { get; set; }
        public string Titel { get; set; }
        public string Sachbearbeiter { get; set; }
    }
}