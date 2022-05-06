using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.DataAccess;
using System.Linq;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly IATMService ATMService;
        private readonly IATMRepo ATMRepo;

        public ATMController(IATMService atmService, IATMRepo aTMRepo)
        {
            ATMService = atmService;
            ATMRepo = aTMRepo;
        }

        [HttpPost]
        //[ProducesResponseType(typeof(bool), 200)]
        //[ProducesResponseType(typeof(bool), 404)]
        public IActionResult GetATM()
        {
            return Ok(ATMRepo.ReturnCardList());
        }

        [HttpGet]
        public Card GetCard(long cardNumber, int pinCode)
        {
            bool isValid = ATMService.Validate(cardNumber, pinCode);
            if (isValid)
            {
                return ATMRepo.ReturnCardList().Single(i => i.Id == cardNumber && i.PinCode == pinCode);
            }
            else
            {
                return null;
            }
        }
    }
}
