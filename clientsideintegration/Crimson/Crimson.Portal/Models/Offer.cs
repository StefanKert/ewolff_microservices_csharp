namespace Crimson.Portal.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Agency { get; set; }
        public string Branch { get; set; }
        public int Claims { get; set; }
        public string Expire { get; set; }
        public double Fee { get; set; }
        public string FormattedFee { get; set; }
        public string Icon { get; set; }
        public string Incident { get; set; }
        public string PaymentInterval { get; set; }
        public string Role { get; set; }
        public string OfferUri { get; set; }
        public string OfferCopyUri { get; set; }
        public string OfferEditUri { get; set; }
        public VehicleData VehicleData { get; set; }
        public Usage Usage { get; set; }
        public InsuranceCover InsuranceCover { get; set; }
    }
}
