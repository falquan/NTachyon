using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
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
            this.crontab = new NTachyon.Api.Crontab.NCrontab();
        }

        // GET api/crontab/0 0 0 * 0 0
        [HttpGet("{expression}")]
        public IActionResult Get(string expression)
        {
            var decodedExpression = Uri.UnescapeDataString(expression);

            if (crontab.IsValid(decodedExpression))
            {
                return new ObjectResult(crontab.Get(decodedExpression));
            }

            return BadRequest(decodedExpression);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CrontabRequest request)
        {
            if (crontab.IsValid(request.Expression))
            {
                return new ObjectResult(crontab.Get(request.Expression));
            }

            return BadRequest(request);
        }
    }
}
