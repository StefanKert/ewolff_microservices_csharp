using System;

namespace Crimson.Portal.Contracts.Backend
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string PartnerURI { get; set; }
        public string Anrede { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public int Alter { get; set; }
        public string Staatsang { get; set; }
        public string Familienstand { get; set; }
        public int AnzahlKinder { get; set; }
        public string Telnummer { get; set; }
        public string Beruf { get; set; }
        public Anschrift Anschrift { get; set; }
        public string Status { get; set; }
    }
}