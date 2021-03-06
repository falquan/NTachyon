using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using NTachyon.Api.Crontab;
using NTachyon.Api.Controllers;
using NSubstitute;
using NTachyon.Api.Test;
using NTachyon.Api.Model;

namespace NCrontab.Api.Test
{
    public class CrontabControllerTests
    {
        private ICrontab mock;
        private ICrontab mockWithResponse;

        public CrontabControllerTests()
        {
            mock = Substitute.For<ICrontab>();
            mock.IsValid(CronExpressions.FiveArguments).Returns(true);
            mock.Get(CronExpressions.FiveArguments, 5).Returns(default(List<DateTime>));

            mockWithResponse = Substitute.For<ICrontab>();
            mockWithResponse.IsValid(CronExpressions.FiveArguments).Returns(true);
            mockWithResponse.Get(CronExpressions.FiveArguments, 5).Returns(
                new List<DateTime>
                {
                    DateTime.Now.AddDays(1),
                    DateTime.Now.AddDays(2),
                    DateTime.Now.AddDays(3),
                    DateTime.Now.AddDays(4),
                    DateTime.Now.AddDays(5),
                }
            );
        }

        [Fact]
        public void Get_WithEscapedValidExpression_ReturnsOk()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Get(CronExpressions.FiveArgumentsUrlEncoded) as OkObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
            mock.Received().Get(Arg.Any<string>(), Arg.Any<int>());
        }

        [Fact]
        public void Get_WithUnescapedValidExpression_ReturnsOk()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Get(CronExpressions.FiveArguments) as OkObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
            mock.Received().Get(Arg.Any<string>(), Arg.Any<int>());
        }

        [Fact]
        public void Get_WithInvalidExpression_ReturnsBadRequest()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Get(CronExpressions.InvalidExpression) as BadRequestObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Get_Null_ReturnsBadRequest()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Get(string.Empty) as BadRequestObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Post_WithValidExpression_ReturnsOk()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Post(
                new CrontabRequest { Expression = CronExpressions.FiveArguments })
                as OkObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
            mock.Received().Get(Arg.Any<string>(), Arg.Any<int>());
        }

        [Fact]
        public void Post_WithInvalidExpression_ReturnsBadRequest()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Post(
                new CrontabRequest { Expression = CronExpressions.InvalidExpression })
                as BadRequestObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Post_WithNull_ReturnsBadRequest()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Post(
                new CrontabRequest())
                as BadRequestObjectResult;

            Assert.NotNull(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Post_WithTriggers_ReturnsOk()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Post(
                new CrontabRequest {
                    Expression = CronExpressions.FiveArguments,
                    Triggers = 10
                });

            Assert.IsType<OkObjectResult>(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Post_WithInvalidExpressionAndTriggers_ReturnsBadRequest()
        {
            var controller = new CrontabController(mock);

            var actual = controller.Post(
                new CrontabRequest {
                    Expression = CronExpressions.InvalidExpression,
                    Triggers = 10
                });

            Assert.IsType<BadRequestObjectResult>(actual);
            mock.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public void Post_WithValidExpression_ReturnsAppropriateObject()
        {
            var controller = new CrontabController(mockWithResponse);

            var actual = controller.Post(
                new CrontabRequest { Expression = CronExpressions.FiveArguments })
                as OkObjectResult;

            var reflected = actual.Value.GetType().GetProperty("Triggers").GetValue(actual.Value);

            Assert.NotNull(reflected);
        }

        [Fact]
        public void Get_WithValidExpression_ReturnsAppropriateObject()
        {
            var controller = new CrontabController(mockWithResponse);

            var actual = controller.Get(CronExpressions.FiveArguments) as OkObjectResult;

            var reflected = actual.Value.GetType().GetProperty("Triggers").GetValue(actual.Value);

            Assert.NotNull(reflected);
        }
    }
}