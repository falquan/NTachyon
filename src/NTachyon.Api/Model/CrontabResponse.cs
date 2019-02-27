namespace NTachyon.Api.Model
{
    using System;
    using System.Collections.Generic;

    public class CrontabResponse
    {
        public IEnumerable<DateTime> Triggers { get; set; }
    }
}