using JG.FinTechTest.API.Exceptions;
using JG.FinTechTest.API.Services;
using JG.FinTechTest.Domain;
using System;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class DeclarationService_UnitTests
    {
        IDeclarationService _declarationService;
        IGiftAidCalculationService _calculationService;

        public DeclarationService_UnitTests()
        {
            Setup();
        }

        private void Setup()
        {
            _calculationService = new GiftAidCalculationService();
            _declarationService = new DeclarationService(_calculationService);
        }

        [Fact]
        public void PrepareDeclaration()
        {
            //Arrange
            double donationAmount = 150;
            var expected = new GiftAidDeclarationResponse()
            {
                DeclarationId=Guid.NewGuid(),
                GiftAidAmount=1.875
            };

            //Act
            var actual=_declarationService.PrepareDeclaration(donationAmount);

            //Assert
            Assert.IsType<GiftAidDeclarationResponse>(actual);
            Assert.Equal(actual.GiftAidAmount, expected.GiftAidAmount);
        }
    }
}
