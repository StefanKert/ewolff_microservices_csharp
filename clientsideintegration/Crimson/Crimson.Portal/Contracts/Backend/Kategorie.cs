using System.Collections.Generic;

namespace Crimson.Portal.Contracts.Backend
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Briefvorlage> Vorlagen { get; set; }
    }
}