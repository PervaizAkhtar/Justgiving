using JG.FinTechTest.API.Controllers;
using JG.FinTechTest.API.Data;
using JG.FinTechTest.API.Exceptions;
using JG.FinTechTest.API.Repositories;
using JG.FinTechTest.API.Services;
using JG.FinTechTest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidController_UnitTests
    {
        private GiftAidDbContext _dbContext;
        private IGiftAidCalculationService _calculationService;
        private IDeclarationService _declarationService;
        public GiftAidController_UnitTests()
        {
            Setup();
        }

        private void Setup()
        {
            var options = new DbContextOptionsBuilder<GiftAidDbContext>()
                          .UseInMemoryDatabase(databaseName: "GiftAidDb").Options;
            _dbContext = new GiftAidDbContext(options);
            _calculationService = new GiftAidCalculationService();
            _declarationService = new DeclarationService(_calculationService);
        }

        [Fact]
        public void CalculeGiftAidAmount()
        {
            IGiftAidRepository aidRepository = new GiftAidRepository(_dbContext);
            GiftAidController controller = new GiftAidController(aidRepository,_calculationService, _declarationService);

            double donationAmount = 150;
            var expected = 1.875;

            var actionResult =  controller.Get(donationAmount);
            var okResult = actionResult as OkObjectResult;
            var actual = (GiftAidResponse) okResult.Value;

            Assert.IsType<GiftAidResponse>(actual);
            Assert.Equal(expected, actual.GiftAidAmount);
        }

        [Fact]
        public async Task SaveDonor()
        {
            IGiftAidRepository aidRepository = new GiftAidRepository(_dbContext);
            GiftAidController controller = new GiftAidController(aidRepository, _calculationService, _declarationService);

            var donor = new Donor()
            {
                Id = Guid.NewGuid(),
                DonationAmount = 150,
                Name="Pervaiz",
                PostCode="LU49FS"
            };

            var expected = 1.875;

            var actionResult = await controller.Post(donor);
            var okResult = actionResult as OkObjectResult;
            var actual = (GiftAidDeclarationResponse)okResult.Value;

            Assert.IsType<GiftAidDeclarationResponse>(actual);
            Assert.Equal(expected, actual.GiftAidAmount);
        }
    }
}
