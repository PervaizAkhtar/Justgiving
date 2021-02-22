using JG.FinTechTest.API.Controllers;
using JG.FinTechTest.API.Exceptions;
using JG.FinTechTest.API.Services;
using JG.FinTechTest.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidController_UnitTests
    {

        [Fact]
        public void GiftAidCalculationService_NegativeAmount()
        {
            IGiftAidCalculationService calculationService = new GiftAidCalculationService();

            GiftAidController controller = new GiftAidController(calculationService);

            double donationAmount = 150;
            var expected = 1.875;

            var actionResult =  controller.Get(donationAmount);
            var okResult = actionResult as OkObjectResult;
            var actual = (GiftAidResponse) okResult.Value;

            Assert.IsType<GiftAidResponse>(actual);
            Assert.Equal(expected, actual.GiftAidAmount);
        }
    }
}
