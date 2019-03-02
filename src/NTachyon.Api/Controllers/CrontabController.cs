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
                var triggers = crontab.Get(decodedExpression, 5);

                return Ok(new CrontabResponse { Triggers = triggers });
            }

            return BadRequest(decodedExpression);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CrontabRequest request)
        {
            if (crontab.IsValid(request.Expression))
            {
                var triggers = crontab.Get(request.Expression, request.Triggers.Value);

                return Ok(new CrontabResponse { Triggers = triggers });
            }

            return BadRequest(request);
        }
    }
}
