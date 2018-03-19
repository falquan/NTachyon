using System;
using System.Collections.Generic;
using System.Linq;
using NCrontab;
using static NCrontab.CrontabSchedule;

namespace NTachyon.Api.Crontab
{
    public class NCrontab : ICrontab
    {
        public bool IsValid(string expression) =>
            CrontabSchedule.TryParse(
                expression, new ParseOptions { IncludingSeconds = expression.Split(' ').Length > 5 })
            == null ? false : true;

        public IEnumerable<DateTime> Get(string expression, int occurances = 5) =>
            CrontabSchedule.Parse(expression, new ParseOptions { IncludingSeconds = expression.Split(' ').Length > 5 })
                           .GetNextOccurrences(DateTime.Now, DateTime.Now.AddYears(occurances))
                           .Take(occurances);
    }
}