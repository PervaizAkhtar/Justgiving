using JG.FinTechTest.API.Exceptions;
using JG.FinTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Services
{
    public class GiftAidCalculationService : IGiftAidCalculationService
    {
        private readonly double _taxRate = 20; // replace with azure key valut

        public double CalculateGiftAmount(double donationAmount)
        {
            if (donationAmount < 0)
            {
                throw new InvalidOperationException("Amount can't be negative value");
            }

            if (donationAmount < 2)
            {
                throw new MinimumDonationException("Minimum donation amount should be £2");
            }

            if (donationAmount > 100000.00)
            {
                throw new MaximumDonationException("Maximum donation amount is £100,000.00");
            }

            return donationAmount / (100 - _taxRate);
        }

        public GiftAidDeclarationResponse PrepareDeclaration(double donationAmount)
        {
            var response = new GiftAidDeclarationResponse();

            response.GiftAidAmount = CalculateGiftAmount(donationAmount);

            response.DeclarationId = Guid.NewGuid();

            return response;
        }
    }
}
