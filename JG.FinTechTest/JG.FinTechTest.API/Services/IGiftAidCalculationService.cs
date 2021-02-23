using JG.FinTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Services
{
    public interface IGiftAidCalculationService
    {
        public double CalculateGiftAmount(double donationAmount);

        public GiftAidDeclarationResponse PrepareDeclaration(double donationAmount);

    }
}
