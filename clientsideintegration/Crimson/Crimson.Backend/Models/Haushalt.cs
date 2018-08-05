using System;

namespace Crimson.Backend.Models
{
    public class Haushalt
    {
        public int PartnerId { get; set; }
        public string Beziehung { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
    }
}