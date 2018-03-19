using System;
using Microsoft.AspNetCore.Mvc;
using NTachyon.Api.Crontab;
using NTachyon.Api.Model;

namespace NTachyon.Api.Controllers
{
    [Route("api/[controller]")]
    public class CrontabController : Controller
    {
        private readonly ICrontab crontab;

        public CrontabController(ICrontab crontab)
        {
            this.crontab = crontab;
        }

        // GET api/crontab/0 0 0 * 0 0
        [HttpGet("{expression}")]
        public IActionResult Get(string expression)
        {
            var decodedExpression = Uri.UnescapeDataString(expression);

            if (crontab.IsValid(decodedExpression))
            {
                return Ok(crontab.Get(decodedExpression, 5));
            }

            return BadRequest(decodedExpression);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CrontabRequest request)
        {
            if (crontab.IsValid(request.Expression))
            {
                return Ok(crontab.Get(
                    request.Expression,
                    request.Triggers.Value));
            }

            return BadRequest(request);
        }
    }
}
