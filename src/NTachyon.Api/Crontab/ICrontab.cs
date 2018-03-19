using System;
using System.Collections.Generic;

namespace NTachyon.Api.Crontab
{
    public interface ICrontab
    {
        bool IsValid(string expression);
        IEnumerable<DateTime> Get(string expression, int occurances);
    }
}