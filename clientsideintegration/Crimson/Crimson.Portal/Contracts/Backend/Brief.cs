using System;

namespace Crimson.Portal.Contracts.Backend
{
    public class Brief
    {
        public string UserId { get; set; }
        public int EntryId { get; set; }
        public DateTime Datum { get; set; }
        public string Text { get; set; }
        public string Bezug { get; set; }
        public int BezugId { get; set; }
        public string BezugURI { get; set; }
        public int PartnerId { get; set; }
    }
}
