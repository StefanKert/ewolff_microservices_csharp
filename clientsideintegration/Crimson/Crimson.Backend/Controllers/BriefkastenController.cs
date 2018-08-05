using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crimson.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BriefkastenController : ControllerBase
    {
        private readonly VertragRepository _vertragRepository;
        private readonly BriefkastenRepository _briefkastenRepository;
        private string serverUrl = ""; //TODO add serverurl
        public BriefkastenController(BriefkastenRepository briefkastenRepository, VertragRepository vertragRepository)
        {
            _briefkastenRepository = briefkastenRepository;
            _vertragRepository = vertragRepository;
        }


        [HttpGet("{userId}")]
        public IActionResult List(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("bad request, id should be an integer");

            var items = _briefkastenRepository.Get(x => x.UserId == userId);

            items.Where(x => !string.IsNullOrEmpty(x.Bezug)).ToList().ForEach(x =>
            {
                var vertraege = _vertragRepository.Get(v => v.PartnerId == x.PartnerId).ToList();
                var vertrag = vertraege[(int)Math.Floor(new Random().NextDouble() * vertraege.Count())];
                x.BezugId = vertrag.Vsnr;
                x.BezugURI = $"{serverUrl}/vertrag/{vertrag.Vsnr}";
            });
            return Ok(items);
        }
    }
}
