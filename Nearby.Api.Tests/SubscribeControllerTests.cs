using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nearby.Api.Controllers;
using Nearby.Api.Data;
using Nearby.Api.Dtos;
using Nearby.Api.Mapping;
using Nearby.Api.Repositories;

namespace Nearby.Api.Tests
{
    [TestClass]
    public class SubscribeControllerTests
    {
        [TestInitialize]
        public void Init() {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<NearbyProfile>();
            });
        }

        [TestMethod] 
         public void TestMapping() {
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Has_Subscribe_Endpoint()
        {
            var controller = new SubscriberController();
            controller.Subscribe(Mock.Of<SubscribeRequestDto>()).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void Has_Ping_Endpoint() {
            var controller = new SubscriberController();
            Assert.AreEqual(controller.Ping(), "pong");
        }

        [TestMethod]
        public void Returns_BadResult_If_Email_Missing()
        {
            // arrange
            var controller = new SubscriberController();
            // act
            var res = controller.Subscribe(new SubscribeRequestDto());
            // assert
            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Calls_Save() {
            // arrange
            var mockRepo = new Mock<IRepository>();
            var controller = new SubscriberController(mockRepo.Object);
            var req = new SubscribeRequestDto()
            {
                Email = "robbymillsap@gmail.com",
                Zipcode = "93311"
            };
            // act
            controller.Subscribe(req);
            // assert
            mockRepo.Verify(m => m.Save(It.IsAny<Subscription>()), Times.Once());
        }
    }
}
