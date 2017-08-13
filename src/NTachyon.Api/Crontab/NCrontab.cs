using System;
using System.Collections.Generic;
using System.Linq;
using NCrontab;

namespace NTachyon.Api.Crontab
{
    public class NCrontab : ICrontab
    {
        public bool IsValid(string expression)
        {
            return CrontabSchedule.TryParse(expression) == null 
                                                         ? false
                                                         : true;
        }

        public IEnumerable<DateTime> Get(string expression, int occurances = 5)
        {
            var schedule = CrontabSchedule.Parse(expression);

            schedule.GetNextOccurrences(DateTime.Now, DateTime.Now.AddYears(occurances));

            return schedule.GetNextOccurrences(DateTime.Now, DateTime.Now.AddYears(occurances))
                           .Take(occurances);

        }
    }
}