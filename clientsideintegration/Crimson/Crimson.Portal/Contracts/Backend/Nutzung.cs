namespace Crimson.Portal.Contracts.Backend
{
    public class Nutzung
    {
        public string BeliebigeFahrer { get; set; }
        public string NachtAbstellplatz { get; set; }
        public int FahrleistungKm { get; set; }
        public int Kilometerstand { get; set; }
        public bool AbweichenderFahrzeughalter { get; set; }
        public string AreaOfUsage { get; set; }
        public bool SelbstGenEigentum { get; set; }
        public string Wohneigentumart { get; set; }
    }
}
