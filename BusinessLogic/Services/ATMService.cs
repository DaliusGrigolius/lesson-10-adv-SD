using BusinessLogic.Interfaces;
using Repository.DataAccess;

namespace BusinessLogic.Services
{
    public class ATMService : IATMService
    {
        public bool Validate(long cardNumber, int pinCode, ATM atm)
        {
            return atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
        }
    }
}
