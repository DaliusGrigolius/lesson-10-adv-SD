using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly ILogger<ATMController> _logger;
        private readonly IATMService _ATMService;
        public ATMController(ILogger<ATMController> logger, IATMService atmService)
        {
            _logger = logger;
            _ATMService = atmService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult GetOther()
        {
            return Ok(_ATMService.Test(1, 2));
        }
    }
}
