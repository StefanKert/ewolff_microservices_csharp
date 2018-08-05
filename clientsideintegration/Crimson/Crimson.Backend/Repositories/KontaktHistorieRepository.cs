using Crimson.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class KontakthistorieRepository
    {
        private static List<Kontakthistorie> _data;
        private readonly string _serverUrl;

        public KontakthistorieRepository(string serverUrl)
        {
            if (_data == null)
                GenerateData();
            this._serverUrl = serverUrl;
        }

        private void GenerateData()
        {
            _data = new List<Kontakthistorie>
            {
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4711, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4712, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4714, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4715, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4716, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4718, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4720, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4722, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4723, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4723, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Telefon", Zeit= "2016-01-15 12=30", Titel= "Beratung"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Email", Zeit= "2016-01-15 12=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4724, Kontaktart= "Telefon", Zeit= "2016-01-15 12=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Telefon", Zeit= "2016-02-15 13=40", Titel= "Beratung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Telefon", Zeit= "2016-02-15 13=50", Titel= "Neue Vertragsunterlagen wegen Ihrer Anpassung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Telefon", Zeit= "2016-02-15 14=40", Titel= "Unterlagen", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Email", Zeit= "2016-02-15 12=40", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Email", Zeit= "2016-02-15 12=41", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Email", Zeit= "2016-02-15 12=42", Titel= "Aktualisierung ihrer Versicherung", Sachbearbeiter= "Jutta Jansen"},
                new Kontakthistorie {PartnerId= 4725, Kontaktart= "Email", Zeit= "2016-02-15 12=43", Titel= "Beratung", Sachbearbeiter= "Maik Thomson"}
            };
        }

        public IEnumerable<Kontakthistorie> Get(Func<Kontakthistorie, bool> predicate) => _data.Where(predicate);
    }
}
