using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class PartnerRepository
    {
        private static List<Partner> _data;
        private readonly string _serverUrl;

        public PartnerRepository(string serverUrl)
        {
            if (_data == null)
                GenerateData();
            this._serverUrl = serverUrl;
        }

        private void GenerateData()
        {
            _data = new List<Partner>
            {
                new Partner { PartnerId= 4711, PartnerURI= $"{_serverUrl}/partner/4711", Anrede= "Herr", Name= "Meyer", Vorname= "Peter", Geburtsdatum= new DateTime(1956, 7, 15), Alter= 59, Staatsang= "deutsch", Familienstand= "verheiratet", AnzahlKinder= 2, Telnummer= "0169 1234567",  Beruf= "Kindergärtner", Anschrift= {Strasse= "Lindenstrasse 11", Plz= "51598", Ort= "Friesenhagen", Stadtteil= "Aaseestadt"},  Status= "Kunde"},
                new Partner { PartnerId= 4712, PartnerURI= $"{_serverUrl}/partner/4712", Anrede= "Frau", Name= "Schmidt", Vorname= "Susanne", Geburtsdatum= new DateTime(1965, 8, 1), Alter= 50, Staatsang= "deutsch", Familienstand= "ledig", AnzahlKinder= 0, Telnummer= "0176 7654354",  Beruf= "Informatiker", Anschrift= {Strasse= "Adalbert-Stifter-Straße 1", Plz= "53474", Ort= "Bad Neuenahr-Ahrweiler", Stadtteil= "Altstadt"},  Status= "Kunde"},
                new Partner { PartnerId = 4713, PartnerURI = $"{_serverUrl}/partner/4713", Anrede = "Herr", Name = "Marx", Vorname = "Benedikt", Geburtsdatum = new DateTime(1974, 4, 23), Alter = 41, Staatsang = "deutsch", Familienstand = "ledig", AnzahlKinder = 1, Telnummer = "0170 5654789",  Beruf = "Bauer", Anschrift = { Strasse = "Ehrenfelsgasse 125a", Plz = "19258", Ort = "Greven", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4714, PartnerURI = $"{_serverUrl}/partner/4714", Anrede = "Herr", Name = "Solinske", Vorname = "Frank", Geburtsdatum = new DateTime(1948, 12, 5), Alter = 67, Staatsang = "spanisch", Familienstand = "ledig", AnzahlKinder = 0, Telnummer = "0171 3567963",  Beruf = "Arzt", Anschrift = { Strasse = "Friedhofallee 8a", Plz = "91522", Ort = "Ansbach", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4715, PartnerURI = $"{_serverUrl}/partner/4715", Anrede = "Frau", Name = "Braun", Vorname = "Ramona", Geburtsdatum = new DateTime(1939, 11, 18), Alter = 76, Staatsang = "deutsch", Familienstand = "geschieden", AnzahlKinder = 3, Telnummer = "0161 8080123",  Beruf = "Consultant", Anschrift = { Strasse = "Friedhofallee 29a", Plz = "91230", Ort = "Happurg Deckersberg", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4716, PartnerURI = $"{_serverUrl}/partner/4716", Anrede = "Frau", Name = "Lehmann", Vorname = "Corinna", Geburtsdatum = new DateTime(1997, 2, 12), Alter = 19, Staatsang = "türkisch", Familienstand = "verheiratet", AnzahlKinder = 4, Telnummer = "0160 7852553",  Beruf = "Innenausstatter", Anschrift = { Strasse = "Imkerweg 18", Plz = "	91807", Ort = "Solnhofen", Stadtteil = "Altstadt"},  Status = "Interessent"},
                new Partner { PartnerId = 4717, PartnerURI = $"{_serverUrl}/partner/4717", Anrede = "Frau", Name = "Breit", Vorname = "Marita", Geburtsdatum = new DateTime(1988, 4, 21), Alter = 27, Staatsang = "russisch", Familienstand = "geschieden", AnzahlKinder = 0, Telnummer = "0177 6573256",  Beruf = "Architekt", Anschrift = { Strasse = "Mozartgasse 15", Plz = "66113", Ort = "Saarbrücken", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4718, PartnerURI = $"{_serverUrl}/partner/4718", Anrede = "Herr", Name = "Müller", Vorname = "Markus", Geburtsdatum = new DateTime(1984, 5, 29), Alter = 31, Staatsang = "deutsch", Familienstand = "verheiratet", AnzahlKinder = 0, Telnummer = "0178 9858145",  Beruf = "Maurer", Anschrift = { Strasse = "Raimundgasse 3", Plz = "81549", Ort = "München", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4719, PartnerURI = $"{_serverUrl}/partner/4719", Anrede = "Herr", Name = "Wiegner", Vorname = "Dennis", Geburtsdatum = new DateTime(1979, 5, 2), Alter = 36, Staatsang = "polnisch", Familienstand = "ledig", AnzahlKinder = 0, Telnummer = "0177 4483695",  Beruf = "Verkäufer", Anschrift = { Strasse = "Schillerstraße 67", Plz = "13465", Ort = "Berlin", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4720, PartnerURI = $"{_serverUrl}/partner/4720", Anrede = "Herr", Name = "Sersch", Vorname = "Christian", Geburtsdatum = new DateTime(1991, 12, 19), Alter = 24, Staatsang = "deutsch", Familienstand = "geschieden", AnzahlKinder = 0, Telnummer = "0171 8351476",  Beruf = "IT Administrator", Anschrift = { Strasse = "Wabenweg 54", Plz = "81549", Ort = "München", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4721, PartnerURI = $"{_serverUrl}/partner/4721", Anrede = "Frau", Name = "Hares", Vorname = "Anna", Geburtsdatum = new DateTime(1957, 9, 30), Alter = 58, Staatsang = "deutsch", Familienstand = "verwitwet", AnzahlKinder = 1, Telnummer = "0176 3653681",  Beruf = "Bürokaufmann", Anschrift = { Strasse = "Gutenbergstraße 76a", Plz = "10585", Ort = "Berlin", Stadtteil = "Charlottenburg"},  Status = "Kunde"},
                new Partner { PartnerId = 4722, PartnerURI = $"{_serverUrl}/partner/4722", Anrede = "Frau", Name = "Hamm", Vorname = "Monika", Geburtsdatum = new DateTime(1964, 4, 6), Alter = 51, Staatsang = "spanisch", Familienstand = "verheiratet", AnzahlKinder = 0, Telnummer = "0175 4520488",  Beruf = "Speditionskaufmann", Anschrift = { Strasse = "Fabrikstraße 98", Plz = "21129", Ort = "Hamburg", Stadtteil = "Altstadt"},  Status = "Interessent"},
                new Partner { PartnerId = 4723, PartnerURI = $"{_serverUrl}/partner/4723", Anrede = "Frau", Name = "Serwe", Vorname = "Ingrid", Geburtsdatum = new DateTime(1981, 1, 9), Alter = 35, Staatsang = "amerikanisch", Familienstand = "ledig", AnzahlKinder = 1, Telnummer = "0174 8821145",  Beruf = "Geschäftsführer", Anschrift = { Strasse = "Erzherzog-Carl-Straße 83", Plz = "48362", Ort = "Münster", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4724, PartnerURI = $"{_serverUrl}/partner/4724", Anrede = "Frau", Name = "Jochem", Vorname = "Sarah", Geburtsdatum = new DateTime(1976, 11, 23), Alter = 39, Staatsang = "deutsch", Familienstand = "verheiratet", AnzahlKinder = 1, Telnummer = "0172 5358792",  Beruf = "Technischer Zeichner", Anschrift = { Strasse = "Dammstraße 21a", Plz = "21129", Ort = "Hamburg", Stadtteil = "Altstadt"},  Status = "Kunde"},
                new Partner { PartnerId = 4725, PartnerURI = $"{_serverUrl}/partner/4725", Anrede = "Herr", Name = "Kirsch", Vorname = "Martin", Geburtsdatum = new DateTime(1986, 7, 27), Alter = 29, Staatsang = "amerikanisch", Familienstand = "geschieden", AnzahlKinder = 0, Telnummer = "0171 2575966",  Beruf = "Student", Anschrift = { Strasse = "Bahnhofstraße 2a", Plz = "14480", Ort = "Potsdam", Stadtteil = "Altstadt"},  Status = "Interessent"},
            };
        }

        public IEnumerable<Partner> Get(Func<Partner, bool> predicate) => _data.Where(predicate);

        public Partner GetById(int id) => _data.FirstOrDefault(x => x.PartnerId == id);

        public IEnumerable<Partner> GetAll() => _data;
    }
}
