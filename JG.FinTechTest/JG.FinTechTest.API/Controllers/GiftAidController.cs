using JG.FinTechTest.API.Data;
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
        private readonly IGiftAidCalculationService _aidCalculationService;
        public GiftAidController(IGiftAidCalculationService aidCalculationService)
        {
            _aidCalculationService = aidCalculationService;
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
    }
}
