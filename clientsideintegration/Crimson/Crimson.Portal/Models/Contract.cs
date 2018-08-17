namespace Crimson.Portal.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public double Fee { get; set; }
        public string FormattedFee { get; set; }
        public string Icon { get; set; }
        public string ContractUri { get; set; }
    }
}
