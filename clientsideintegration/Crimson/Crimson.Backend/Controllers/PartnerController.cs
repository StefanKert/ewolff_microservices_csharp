using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Models;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [Route("partners")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly PartnerRepository _partnerRepository;
        private readonly HaushaltRepository _haushaltRepository;
        private readonly KontakthistorieRepository _kontakthistorieRepository;


        public PartnerController(PartnerRepository partnerRepository, HaushaltRepository haushaltRepository, KontakthistorieRepository kontakthistorieRepository)
        {
            _partnerRepository = partnerRepository;
            _haushaltRepository = haushaltRepository;
            _kontakthistorieRepository = kontakthistorieRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Partner>> Get([FromQuery]string q)
        {
            var partners = _partnerRepository.GetAll();
            if (!string.IsNullOrEmpty(q))
            {
                var query = q.ToLower();
                partners = partners.Where(partner =>
                {
                    var name = partner.Vorname.ToLower() + ' ' + partner.Name.ToLower();
                    return name.Contains(query) || partner.PartnerId.ToString().Contains(query);
                });
            }
            return Ok(partners);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Partner> Get(int id)
        {
            var partner = _partnerRepository.GetById(id);
            if (partner == null)
                return NotFound();
            return Ok(partner);
        }

        [HttpGet("{id:int}/haushalt")]
        public ActionResult<IEnumerable<Haushalt>> GetHaushalt(int id)
        {
            var result = _haushaltRepository.Get(x => x.PartnerId == id);
            return Ok(result);
        }


        [HttpGet("{id:int}/kontakt")]
        public ActionResult<Partner> GetKontakte(int id)
        {
            var result = _kontakthistorieRepository.Get(x => x.PartnerId == id);
            return Ok(result);
        }
    }
}
