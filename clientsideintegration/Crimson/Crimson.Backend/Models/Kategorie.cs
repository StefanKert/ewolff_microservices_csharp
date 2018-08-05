using System.Collections.Generic;

namespace Crimson.Backend.Models
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Briefvorlage> Vorlagen { get; set; }
    }
}