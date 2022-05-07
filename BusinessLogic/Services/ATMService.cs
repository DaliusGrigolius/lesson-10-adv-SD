using BusinessLogic.Interfaces;
using Repository.DataAccess;

namespace BusinessLogic.Services
{
    public class ATMService : IATMService
    {
        private readonly ATMRepo ATMRepo;
        public ATMService(ATMRepo aTMRepo)
        {
            ATMRepo = aTMRepo;
        }

        public bool Validate(long cardNumber, int pinCode)
        {
            ATM atm = ATMRepo.RetrieveATM();
            return atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
        }
    }
}
