using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class HaushaltRepository
    {
        private static List<Haushalt> _data;

        public HaushaltRepository()
        {
            if (_data == null)
                GenerateData();
        }

        private void GenerateData()
        {
            _data = new List<Haushalt>
            {
                new Haushalt {PartnerId= 4711, Beziehung= "Lebensgefährte", Name= "Schmitt", Vorname= "Petra", Geburtsdatum= new DateTime(1974, 4, 23)},
                new Haushalt {PartnerId= 4712, Beziehung= "Lebensgefährte", Name= "Bayer", Vorname= "Klaus", Geburtsdatum= new DateTime(1976, 6, 30) },
                new Haushalt {PartnerId= 4712, Beziehung= "Lebensgefährte", Name= "Marx", Vorname= "Timo", Geburtsdatum= new DateTime(1968, 5, 1) },
                new Haushalt {PartnerId= 4714, Beziehung= "Lebensgefährte", Name= "Solinske", Vorname= "Clara", Geburtsdatum= new DateTime(1983, 12, 5)},
                new Haushalt {PartnerId= 4715, Beziehung= "Lebensgefährte", Name= "Müller", Vorname= "Selma", Geburtsdatum= new DateTime(1975, 11, 9)},
                new Haushalt {PartnerId= 4715, Beziehung= "Lebensgefährte", Name= "Braun", Vorname= "Giovanni", Geburtsdatum= new DateTime(1976, 1, 11)},
                new Haushalt {PartnerId= 4717, Beziehung= "Lebensgefährte", Name= "Wiegner", Vorname= "Nina", Geburtsdatum= new DateTime(1962, 2, 25)},
                new Haushalt {PartnerId= 4718, Beziehung= "Lebensgefährte", Name= "Müller", Vorname= "Carina", Geburtsdatum= new DateTime(1990, 8, 21)},
                new Haushalt {PartnerId= 4720, Beziehung= "Lebensgefährte", Name= "Serwe", Vorname= "Maraike", Geburtsdatum= new DateTime(1972, 11, 17)},
                new Haushalt {PartnerId= 4720, Beziehung= "Lebensgefährte", Name= "Kirsch", Vorname= "Ursula", Geburtsdatum= new DateTime(1975, 2, 28)}
            };
        }

        public IEnumerable<Haushalt> Get(Func<Haushalt, bool> predicate) => _data.Where(predicate);
    }
}
