using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class BerufRepository
    {
        private static List<Beruf> _data;

        public BerufRepository()
        {
            if (_data == null)
                GenerateData();
        }

        private void GenerateData()
        {
            _data = new List<Beruf>
            {
                new Beruf { BerufId= 1, Name= "Kindergärtner" },
                new Beruf { BerufId= 2, Name= "Informatiker" },
                new Beruf { BerufId= 3, Name= "Bauer" },
                new Beruf { BerufId= 4, Name= "Arzt" },
                new Beruf { BerufId= 5, Name= "Innenausstatter" },
                new Beruf { BerufId= 6, Name= "Consultant" },
                new Beruf { BerufId=  7, Name= "Architekt" },
                new Beruf { BerufId= 8, Name= "Maurer" },
                new Beruf { BerufId= 9, Name= "Verkäufer" },
                new Beruf { BerufId= 10, Name= "IT Administrator" },
                new Beruf { BerufId= 11, Name= "Bürokaufmann" },
                new Beruf { BerufId= 12, Name= "Speditionskaufmann" },
                new Beruf { BerufId= 13, Name= "Geschäftsführer" },
                new Beruf { BerufId= 14, Name= "Technischer Zeichner" },
                new Beruf { BerufId= 15, Name= "Student" },
                new Beruf { BerufId= 16, Name= "Key Account Manager" },
                new Beruf { BerufId= 17, Name= "Sales Executive" },
                new Beruf{ BerufId= 18, Name= "Developer" },
                new Beruf { BerufId= 19, Name= "Softwareentwickler" }
            };
        }

        public IEnumerable<Beruf> Get(Func<Beruf, bool> predicate) => _data.Where(predicate);

        public IEnumerable<Beruf> GetAll() => _data;
    }
}
