using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nearby.Api.Controllers;
using Nearby.Api.Dtos;

namespace Nearby.Api.Tests
{
    [TestClass]
    public class SubscribeControllerTests
    {
        [TestMethod]
        public void Has_Subscribe_Endpoint()
        {
            var controller = new SubscriberController();
            controller.Subscribe(Mock.Of<SubscribeRequestDto>());
        }

        [TestMethod]
        public void Has_Ping_Endpoint() {
            var controller = new SubscriberController();
            Assert.AreEqual(controller.Ping(), "pong");
        }
    }
}
