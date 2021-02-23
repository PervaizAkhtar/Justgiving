using JG.FinTechTest.API.Data;
using JG.FinTechTest.API.Repositories;
using JG.FinTechTest.API.Services;
using JG.FinTechTest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/giftaid")]
    public class GiftAidController : ControllerBase
    {
        private readonly IGiftAidRepository  _aidRepository;
        private readonly IGiftAidCalculationService _aidCalculationService;
        private readonly IDeclarationService _declarationService;
        public GiftAidController(IGiftAidRepository aidRepository, IGiftAidCalculationService aidCalculationService,
            IDeclarationService declarationService)
        {
            _aidRepository = aidRepository;
            _aidCalculationService = aidCalculationService;
            _declarationService = declarationService;
        }


        /// <summary>
        /// Get the amount of gift aid reclaimable for donation amount
        /// </summary>
        /// <param name="number"></param>
        /// <returns>GiftAidResponse</returns>
        [HttpGet]
        public IActionResult Get(double number)
        {
            var giftAidResponse = new GiftAidResponse();
            if (number > 0)
            {
                giftAidResponse.DonationAmount = number;
                giftAidResponse.GiftAidAmount = _aidCalculationService.CalculateGiftAmount(number);
            }
            return Ok(giftAidResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Donor donor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

             await _aidRepository.SaveDonor(donor);

            var response = _declarationService.PrepareDeclaration(donor.DonationAmount);

            return Ok(response);
        }
    }
}
