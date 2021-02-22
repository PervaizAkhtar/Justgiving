using JG.FinTechTest.API.Exceptions;
using JG.FinTechTest.API.Services;
using System;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidCalculationService_UnitTests
    {
        IGiftAidCalculationService calculationService = new GiftAidCalculationService();

        [Fact]
        public void GiftAidCalculationService_NegativeAmount()
        {
            double donationAmount = -1;

            var ex = Assert.Throws<InvalidOperationException>(() => calculationService.CalculateGiftAmount(donationAmount));

            Assert.Equal("Amount can't be negative value", ex.Message);

        }

        [Fact]
        public void GiftAidCalculationService_CheckMinimumDonation()
        {
            double donationAmount = 1;

            var ex = Assert.Throws<MinimumDonationException>(() => calculationService.CalculateGiftAmount(donationAmount));

            Assert.Equal("Minimum donation amount should be £2", ex.Message);

        }

        [Fact]
        public void GiftAidCalculationService_CheckMaximumDonation()
        {
            double donationAmount = 100111.00;

            var ex = Assert.Throws<MaximumDonationException>(() => calculationService.CalculateGiftAmount(donationAmount));

            Assert.Equal("Maximum donation amount is £100,000.00", ex.Message);
        }

        [Fact]
        public void GiftAidCalculationService_CalculateGiftAmount()
        {
            double donationAmount = 150;

            var expected = 1.875;

            var actual = calculationService.CalculateGiftAmount(donationAmount);

            Assert.Equal(actual, expected);
        }

    }
}
