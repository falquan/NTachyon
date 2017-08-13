using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NCrontab;
using NTachyon.Api.Crontab;

namespace NTachyon.Api.Test
{
    public class NCrontabTests
    {
        [Fact]
        public void IsValid_WithValidExpression_ReturnsTrue()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            var actual = crontab.IsValid(CronExpressions.FiveArguments);

            Assert.True(actual);
        }

        [Fact]
        public void IsValid_WithInvalidExpression_ReturnsFalse()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            var actual = crontab.IsValid(CronExpressions.InvalidExpression);

            Assert.False(actual);
        }

        [Fact]
        public void Get_WithoutOccurances_ReturnsFiveTimestamps()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            var actual = crontab.Get(CronExpressions.FiveArguments);

            Assert.True(actual.Count() == 5);
        }

        [Fact]
        public void Get_WithTwoOccurances_ReturnsTwoTimestamps()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            var actual = crontab.Get(CronExpressions.FiveArguments, 2);

            Assert.True(actual.Count() == 2);
        }

        [Fact]
        public void Get_WithValidExpression_Returns()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            var actual = crontab.Get(CronExpressions.FiveArguments);

            Assert.NotNull(actual);
        }

        [Fact]
        public void Get_WithInvalidExpression_Throws()
        {
            var crontab = new NTachyon.Api.Crontab.NCrontab();

            Action actual = () => crontab.Get(CronExpressions.InvalidExpression);

            Assert.Throws<CrontabException>(actual);
        }
    }
}
