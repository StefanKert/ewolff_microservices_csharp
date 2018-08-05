using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Models;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchadenController : ControllerBase
    {
        private readonly PartnerRepository _partnerRepository;
        private readonly VertragRepository _vertragRepository;

        public SchadenController(PartnerRepository partnerRepository, VertragRepository vertragRepository)
        {
            _partnerRepository = partnerRepository;
            _vertragRepository = vertragRepository;
        }

        [HttpGet("{sparte}/vorbelegung")]
        public IActionResult GetVorbelegung(string sparte, [FromQuery]int partnerId, [FromQuery]int vsnr)
        {
            if (sparte.ToLower() != "kraftfahrt")
                return BadRequest("sparte is invalid");
            if (partnerId < 1)
                return BadRequest("bad request, partnerId should be set");
            if (vsnr < 1)
                return BadRequest("bad request, vsnr should be set");


            var partner = _partnerRepository.GetById(partnerId);
            if (partner == null)
                return NotFound();

            var vertrag = _vertragRepository.GetByVsnr(vsnr);
            if (vertrag == null)
                return NotFound();

            var result = new
            {
                Vsnr = vertrag.Vsnr,
                Anschrift = partner.Anschrift
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Angebot model)
        {
            //if (model == null)
            //    return BadRequest("Body should not be empty");
            //if (model.PartnerId < 1)
            //    return BadRequest("partnerId is not set");

            //_angebotRepository.Create(model);
            return Created($"/angebot/{model.AngebotId}", model);
        }

    }
}
