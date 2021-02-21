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
      

        private readonly ILogger<GiftAidController> _logger;

        public GiftAidController(ILogger<GiftAidController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello Word");
        }
    }
}
