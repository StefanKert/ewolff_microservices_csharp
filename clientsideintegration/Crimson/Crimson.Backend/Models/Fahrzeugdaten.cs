namespace Crimson.Backend.Models
{
    public class Fahrzeugdaten
    {
        public string Fahrzeugart { get; set; }
        public string Kennzeichen { get; set; }
        public int Hsn { get; set; }
        public int Typschl { get; set; }
        public string Erstzulassung { get; set; }
        public string Fahrgestell { get; set; }
        public int FahrzeugstaerkePS { get; set; }
        public bool Austauschmotor { get; set; }
        public string Kennzeichenart { get; set; }
        public bool Wechselkennzeichen { get; set; }
    }
}
