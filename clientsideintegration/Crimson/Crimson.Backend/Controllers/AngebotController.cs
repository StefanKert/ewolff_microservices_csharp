using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Crimson.Backend.Models;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [ApiController]
    public class AngebotController : ControllerBase
    {
        private readonly AngebotRepository _angebotRepository;
        private readonly PartnerRepository _partnerRepository;

        public AngebotController(AngebotRepository angeboteRepository, PartnerRepository partnerRepository)
        {
            this._angebotRepository = angeboteRepository;
            this._partnerRepository = partnerRepository;
        }

        [HttpGet("angebote")]
        public IActionResult Get([FromQuery]int partnerId, [FromQuery]string mode = "list")
        {
            var angebote = _angebotRepository.Get(x => x.PartnerId == partnerId).Select(p => new
            {
                AngebotId = p.AngebotId,
                PartnerId = p.PartnerId,
                Sparte = p.Sparte,
                Rolle = p.Rolle,
                Agentur = p.Agentur,
                Versichrtist = p.Versichertist,
                Schaeden = p.Schaeden,
                Ablauf = p.Ablauf,
                Zahlungsweise = p.Zahlungsweise,
                BeitragZent = p.BeitragZent,
                AngebotURI = p.AngebotURI
            });

            if (mode == "list")
                return Ok(angebote);
            else
                return Ok(angebote.Count());
        }

        [HttpGet("angebote/{id:int}")]
        public ActionResult<Angebot> Get(int id)
        {
            var angebot = _angebotRepository.GetById(id);
            if (angebot == null)
                return NotFound();
            return Ok(angebot);
        }

        [HttpGet("angebot/{sparte}/vorbelegung")]
        public IActionResult GetVorbelegung(string sparte, [FromQuery]int partnerId)
        {
            if (sparte.ToLower() != "kraftfahrt")
                return BadRequest("sparte is invalid");
            if (partnerId < 1)
                return BadRequest("bad request, partnerId should be set");

            var partner = _partnerRepository.GetById(partnerId);
            if (partner == null)
                return NotFound();
            var result = new
            {
                Geburtsdatum = partner.Geburtsdatum,
                Anschrift = partner.Anschrift,
                Zahlungsweise = new List<Zahlungsweise> {
                    new Zahlungsweise
                    {
                        Id = 1,
                        Name = "monatlich"
                    },
                    new Zahlungsweise
                    {
                        Id = 2,
                        Name = "jährlich"
                    }
                }
            };
            return Ok(result);
        }

        [HttpPost("angebot/{sparte}/berechnen")]
        public IActionResult Calculate(string sparte, [FromBody] Angebot model)
        {
            if (sparte.ToLower() != "kraftfahrt")
            {
                return BadRequest("sparte is invalid");
            }

            var result = new List<object>();
            var errorCount = Math.Floor(new Random().NextDouble() * 6) + 1;
            var randomPropertyNames = new List<string>();

            for (var i = 0; i < errorCount; i++)
            {
                var randomPropertyName = GetRandomPropertyName(model);

                if (randomPropertyNames.IndexOf(randomPropertyName) > -1)
                {
                    continue;
                }

                randomPropertyNames.Add(randomPropertyName);
                result.Add(CreateError(randomPropertyName));
            }

            return BadRequest(result);
        }

        private string GetRandomPropertyName<T>(T model)
        {
            var properties = model.GetType().GetProperties();
            PropertyInfo property = null;
            do
            {
                property = properties[(int)Math.Floor(new Random().NextDouble() * properties.Length)];
            }
            while (property.Name.ToLower().Contains("id") || property.Name.ToLower().Contains("uri"));

            var value = property.GetValue(model);
            var result = property.Name;
            if (value.GetType() != typeof(string) && value.GetType().IsClass)
            {
                result += '.' + GetRandomPropertyName(value);
            }
            return result;
        }

        private object CreateError(string bezugsFeld)
        {
            return new
            {
                FehlerId = Math.Floor(new Random().NextDouble() * 100) + 1,
                FehlerKategorie = Math.Floor(new Random().NextDouble() * 3),
                FehlerText = "Bitte denken Sie sich Ihre eigene Fehlermeldung aus.",
                BezugsFeld = bezugsFeld
            };
        }

        [HttpPost("angebot")]
        public IActionResult Post([FromBody] Angebot model)
        {
            if (model == null)
                return BadRequest("Body should not be empty");
            if (model.PartnerId < 1)
                return BadRequest("partnerId is not set");

            _angebotRepository.Create(model);
            return Created($"/angebot/{model.AngebotId}", model);
        }

        [HttpPost("angebot/{id:int}")]
        public IActionResult Copy(int id)
        {
            if (id > 1)
            {
                return BadRequest("angebotId should be an integer");
            }

            var angebot = _angebotRepository.GetById(id);
            if (angebot == null)
                return NotFound();

            angebot.AngebotId = -1; // Reset angebotId
            _angebotRepository.Create(angebot);
            return Created($"/angebot/{angebot.AngebotId}", angebot);
        }
    }
}
