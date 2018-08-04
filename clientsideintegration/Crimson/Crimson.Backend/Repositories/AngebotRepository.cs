using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class AngebotRepository
    {
        private static List<Angebot> _data;
        private readonly string _serverUrl;

        public AngebotRepository(string serverUrl)
        {
            if (_data == null)
                GenerateData();
            _serverUrl = serverUrl;
        }

        private void GenerateData()
        {
            _data = new List<Angebot>();
            var currentId = 0;
            for (var i = 0; i < 75; i++)
            {
                var angebotId = currentId++;
                _data.Add(new Angebot
                {
                    AngebotId = angebotId,
                    PartnerId = 4711 + (currentId % 15),
                    AngebotURI = $"{_serverUrl}/angebot/{angebotId}",
                    Sparte = "Kraftfahrt",
                    Rolle = "Versicherungsnehmer",
                    Agentur = "2008/21",
                    Versichertist = "M-RS 6",
                    Schaeden = 0,
                    Ablauf = "",
                    Zahlungsweise = "jährlich",
                    BeitragZent = 9999,
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

        public Angebot GetById(int id) => _data.FirstOrDefault(x => x.AngebotId == id);

        public IEnumerable<Angebot> Get(Func<Angebot, bool> predicate) => _data.Where(predicate);

        public void Create(Angebot angebot)
        {
            angebot.AngebotId = _data.Count + 1;
            angebot.AngebotURI = $"{_serverUrl}/angebot/{angebot.AngebotId}";
            _data.Add(angebot);
        }
    }
}
