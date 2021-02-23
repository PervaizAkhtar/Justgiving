using JG.FinTechTest.API.Repositories;
using JG.FinTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Services
{
    public class DeclarationService : IDeclarationService
    {
        private readonly IGiftAidCalculationService _aidCalculationService;
        public DeclarationService(IGiftAidCalculationService aidCalculationService)
        {
            _aidCalculationService = aidCalculationService;
        }

        public GiftAidDeclarationResponse PrepareDeclaration(double donationAmount)
        {
            var response = new GiftAidDeclarationResponse();

            response.GiftAidAmount = _aidCalculationService.CalculateGiftAmount(donationAmount);

            response.DeclarationId = Guid.NewGuid();

            return response;
        }
    }
}
