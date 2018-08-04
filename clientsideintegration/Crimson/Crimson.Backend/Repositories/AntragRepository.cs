using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class AntragRepository
    {
        private static List<Antrag> _data;

        public AntragRepository()
        {
            if (_data == null)
                GenerateData();
        }

        private void GenerateData()
        {
            _data = new List<Antrag>();
            var currentId = 0;
            for (var i = 0; i < 44; i++)
            {
                var antragId = currentId++;
                _data.Add(new Antrag
                {
                    AntragId = antragId,
                    PartnerId = 4711 + (currentId % 15),
                    Sparte = "Kraftfahrt",
                    BeitragZent = Math.Floor(new Random().NextDouble() * 40000 + 2000)
                });
            }
        }

        public IEnumerable<Antrag> Get(Func<Antrag, bool> predicate) => _data.Where(predicate);
    }
}
