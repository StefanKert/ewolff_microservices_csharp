﻿namespace Crimson.Portal.Contracts.Backend
{
    public class Antrag
    {
        public int AntragId { get; set; }
        public int PartnerId { get; set; }
        public string Sparte { get; set; }
        public double BeitragZent { get; set; }
    }
}
