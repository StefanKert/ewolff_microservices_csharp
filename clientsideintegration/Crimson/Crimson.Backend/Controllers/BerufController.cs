using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [Route("berufe")]
    [ApiController]
    public class BerufController : ControllerBase
    {
        private readonly BerufRepository _berufRepository;

        public BerufController(BerufRepository berufRepository)
        {
            _berufRepository = berufRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string q)
        {
            if (string.IsNullOrEmpty(q))
                return Ok(_berufRepository.GetAll());
            return Ok(_berufRepository.Get(x => x.Name.ToLower().Contains(q.ToLower())));
        }
    }
}
