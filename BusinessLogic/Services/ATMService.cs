using Repository.DataAccess;
using System.Linq;

namespace BusinessLogic.Services
{
    public class ATMService
    {
        ATMRepo ATMRepo = new ATMRepo();

        public bool Validate(long cardNumber, int pinCode)
        {
            ATM atm = ATMRepo.RetrieveATM();
            bool cardIsValid = atm.CardsList.Any(i => i.Id == cardNumber);
            bool pinCodeIsValid = atm.CardsList.Any(i => i.PinCode == pinCode);
            if (cardIsValid && pinCodeIsValid) return true;
            return false;
        }
    }
}
