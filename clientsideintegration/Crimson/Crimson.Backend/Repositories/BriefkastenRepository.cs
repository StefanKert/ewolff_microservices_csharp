using Crimson.Backend.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crimson.Backend.Repositories
{
    public class BriefkastenRepository
    {
        private static List<Brief> _data;
        private readonly AppOptions _options;

        public BriefkastenRepository(IOptions<AppOptions> optionsAccessor)
        {
            if (_data == null)
                GenerateData();
            _options = optionsAccessor.Value;
        }

        private void GenerateData()
        {
            _data = new List<Brief>
            {
                new Brief { UserId= "m50000", EntryId= 7710, Datum= new DateTime(2016, 03, 1), Text= "UB-Vorlage", Bezug= null, BezugId= -1, BezugURI= null, PartnerId= 4711 },
                new Brief { UserId= "m50000", EntryId= 7711, Datum= new DateTime(2016, 03, 2), Text= "Wiedervorlage", Bezug= "Vertrag", BezugId= 6711, BezugURI= $"{_options.ServerUrl}/vertrag/6711", PartnerId= 4712 },
                new Brief { UserId= "m50000", EntryId= 7712, Datum= new DateTime(2016, 03, 3), Text= "UB-Vorlage", Bezug= null, BezugId= -1, BezugURI= null ,PartnerId= 4711},
                new Brief { UserId= "m50000", EntryId= 7713, Datum= new DateTime(2016, 03, 4), Text= "Wiedervorlage", Bezug= "Vertrag", BezugId= 6712, BezugURI= $"{_options.ServerUrl}/vertrag/6712" ,PartnerId= 4712},
                new Brief { UserId= "m50000", EntryId= 7714, Datum= new DateTime(2016, 03, 5), Text= "UB-Vorlage", Bezug= null, BezugId= -1, BezugURI= null ,PartnerId= 4713},
                new Brief { UserId= "m50000", EntryId= 7715, Datum= new DateTime(2016, 03, 6), Text= "Wiedervorlage", Bezug= "Vertrag", BezugId= 6713, BezugURI= $"{_options.ServerUrl}/vertrag/6713" ,PartnerId= 4714},
                new Brief { UserId= "m50000", EntryId= 7716, Datum= new DateTime(2016, 03, 7), Text= "UB-Vorlage", Bezug= null, BezugId= -1, BezugURI= null ,PartnerId= 4717},
                new Brief { UserId= "m50000", EntryId= 7717, Datum= new DateTime(2016, 03, 8), Text= "Wiedervorlage", Bezug= "Vertrag", BezugId= 6714, BezugURI= $"{_options.ServerUrl}/vertrag/6714" ,PartnerId= 4719},
                new Brief { UserId= "m50000", EntryId= 7718, Datum= new DateTime(2016, 03, 9), Text= "UB-Vorlage", Bezug= null, BezugId= -1, BezugURI= null ,PartnerId= 4712},
                new Brief { UserId= "m50000", EntryId= 7719, Datum= new DateTime(2016, 03, 10), Text= "Wiedervorlage", Bezug= "Vertrag", BezugId= 6715, BezugURI= $"{_options.ServerUrl}/vertrag/6715" ,PartnerId= 4718}
            };
        }

        public IEnumerable<Brief> Get(Func<Brief, bool> predicate) => _data.Where(predicate);
    }
}