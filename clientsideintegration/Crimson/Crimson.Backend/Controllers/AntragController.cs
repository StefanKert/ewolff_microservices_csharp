using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [Route("antraege")]
    [ApiController]
    public class AntragController : ControllerBase
    {
        private readonly AntragRepository _antragRepository;

        public AntragController(AntragRepository antragRepository)
        {
            this._antragRepository = antragRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]int partnerId, [FromQuery]string mode = "list")
        {
            var antraege = _antragRepository.Get(x => x.PartnerId == partnerId);
            if (mode == "list")
                return Ok(antraege);
            else
                return Ok(antraege.Count());
        }
    }
}
