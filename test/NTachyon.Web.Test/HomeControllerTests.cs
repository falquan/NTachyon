using System;
using Microsoft.AspNetCore.Mvc;
using NTachyon.Web.Controllers;
using Xunit;

namespace NTachyon.Web.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Error()
        {
            var controller = new HomeController();

            var result = controller.Error() as ViewResult;

            Assert.NotNull(result);
        }
    }
}
