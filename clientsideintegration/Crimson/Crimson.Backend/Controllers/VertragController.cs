using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Models;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [ApiController]
    public class VertragController : ControllerBase
    {
        private readonly VertragRepository _vertragRepository;

        public VertragController(VertragRepository vertragRepository)
        {
            this._vertragRepository = vertragRepository;
        }

        [HttpGet("vertraege")]
        public IActionResult Get([FromQuery]int partnerId, [FromQuery]string mode = "list")
        {
            var angebote = _vertragRepository.Get(x => x.PartnerId == partnerId).Select(p => new
            {
                Sparte = p.Sparte,
                BeitragZent = p.BeitragZent,
                VertragURI = p.VertragURI,
                Vsnr = p.Vsnr,
                PartnerId = p.PartnerId
            });

            if (mode == "list")
                return Ok(angebote);
            else
                return Ok(angebote.Count());
        }

        [HttpGet("vertrag/{id:int}")]
        public ActionResult<Vertrag> Get(int id)
        {
            var vertrag = _vertragRepository.GetByVsnr(id);
            if (vertrag == null)
                return NotFound();
            return Ok(vertrag);
        }


        [HttpGet("vertrag/{id:int}/briefvorlagen")]
        public ActionResult<Vertrag> GetBriefvorlagen(int id)
        {
            if (id < 1)
                return BadRequest("bad request, id should be an integer");
            var vertrag = _vertragRepository.GetByVsnr(id);
            if (vertrag == null)
                return NotFound();

            var result = new
            {
                Kategorien = new List<Kategorie>
                {
                    new Kategorie
                    {
                        Id = 1,
                        Name = "Risiko Unfallversicherung",
                        Vorlagen = new List<Briefvorlage>
                        {
                            new Briefvorlage
                            {
                                Id= 10,
                                Name= "Kündigung"
                            },
                            new Briefvorlage
                            {
                                Id= 11,
                                Name= "Allgemeine Mitteilung"
                            }
                        }
                    },
                    new Kategorie
                    {
                        Id = 2,
                        Name = "Freitext",
                        Vorlagen = new List<Briefvorlage>
                        {
                            new Briefvorlage
                            {
                                Id= 20,
                                Name= "VT12 Freier Text"
                            },
                            new Briefvorlage
                            {
                                Id= 21,
                                Name= "VT13 Freier Text mit Rückantwort"
                            }
                        }
                    }
                }
            };

            return Ok(result);
        }


        [HttpGet("vertrag/{id:int}/briefempfaenger")]
        public ActionResult<Vertrag> GetBriefempfaenger(int id)
        {
            if (id < 1)
                return BadRequest("bad request, id should be an integer");
            var vertrag = _vertragRepository.GetByVsnr(id);
            if (vertrag == null)
                return NotFound();

            var result = new
            {
                Kategorien = new List<Kategorie>
                {
                    new Kategorie
                    {
                        Id = 1,
                        Name = "Risiko Unfallversicherung",
                        Vorlagen = new List<Briefvorlage>
                        {
                            new Briefvorlage
                            {
                                Id= 10,
                                Name= "Kündigung"
                            },
                            new Briefvorlage
                            {
                                Id= 11,
                                Name= "Allgemeine Mitteilung"
                            }
                        }
                    },
                    new Kategorie
                    {
                        Id = 2,
                        Name = "Freitext",
                        Vorlagen = new List<Briefvorlage>
                        {
                            new Briefvorlage
                            {
                                Id= 20,
                                Name= "VT12 Freier Text"
                            },
                            new Briefvorlage
                            {
                                Id= 21,
                                Name= "VT13 Freier Text mit Rückantwort"
                            }
                        }
                    }
                }
            };

            return Ok(result);
        }
    }
}
