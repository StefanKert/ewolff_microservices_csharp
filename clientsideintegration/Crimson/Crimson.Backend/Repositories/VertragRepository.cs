using Crimson.Backend.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class VertragRepository
    {
        private static List<Vertrag> _data;
        private readonly AppOptions _options;

        public VertragRepository(IOptions<AppOptions> optionsAccessor)
        {
            if (_data == null)
                GenerateData();
            _options = optionsAccessor.Value;
        }

        private void GenerateData()
        {
            _data = new List<Vertrag>();
            var currentId = 0;
            for (var i = 0; i < 44; i++)
            {
                var vsnr = (int) Math.Floor(new Random().NextDouble() * 899999999 + 100000000);
                _data.Add(new Vertrag
                {
                    Vsnr = vsnr,
                    Sparte = "Kraftfahrt",
                    PartnerId = 4711 + (currentId++ % 15),
                    BeitragZent = (int)Math.Floor(new Random().NextDouble() * 40000 + 2000),
                    VertragURI = $"{_options.ServerUrl}/vertrag/{vsnr}",
                    Fahrzeugdaten = new Fahrzeugdaten
                    {
                        Fahrzeugart = "PKW",
                        Kennzeichen = "MS-CH 444",
                        Hsn = 432,
                        Typschl = 234,
                        Erstzulassung = "20.05.2015",
                        Fahrgestell = "dj3rij35j42",
                        FahrzeugstaerkePS = 340,
                        Austauschmotor = false,
                        Kennzeichenart = "schwarzes Kennzeichen",
                        Wechselkennzeichen = false
                    },
                    Vorschaeden = new List<Schaden>
                    {
                        new Schaden
                        {
                            Datum = new DateTime(2015, 7, 20),
                            SchadenHoehe = 3500
                        },
                        new Schaden
                        {
                            Datum = new DateTime(2015, 9, 20),
                            SchadenHoehe = 1500
                        }
                    },
                    Vorversicherer = new List<Versicherer>
                    {
                        new Versicherer
                        {
                            Name = "HUK",
                            KuendigungsGrund = "durch Versicherungsnehmer"
                        },
                        new Versicherer
                        {
                            Name = "Allianz",
                            KuendigungsGrund = "Schaden"
                        }
                    },
                    Nutzung = new Nutzung
                    {
                        BeliebigeFahrer = "unbekannt",
                        NachtAbstellplatz = "Straßenrand",
                        FahrleistungKm = 30000,
                        Kilometerstand = 120433,
                        AbweichenderFahrzeughalter = false,
                        nutzung = "privat",
                        SelbstGenEigentum = true,
                        Wohneigentumart = "Wohnung"

                    },
                    VersSchutz = new VersSchutz
                    {
                        HaftpflichSFR = "SF0 10%",
                        VolkaskoSFR = "SF0 57%",
                        Tarifgruppe = "normal",
                        Rahmenvertrag = "keiner",
                        VersBeginn = "25.02.2016",
                        Zahlungsweise = "monatlich"

                    }
                });
            }
        }

        public Vertrag GetByVsnr(int vsnr) => _data.FirstOrDefault(x => x.Vsnr == vsnr);

        public IEnumerable<Vertrag> Get(Func<Vertrag, bool> predicate) => _data.Where(predicate);

    }
}
