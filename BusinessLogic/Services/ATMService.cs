using BusinessLogic.Interfaces;
using Repository.DataAccess;

namespace BusinessLogic.Services
{
    public class ATMService : IATMService
    {
        private readonly IATMRepo _ATMRepo;

        public ATMService(IATMRepo aTMRepo)
        {
            _ATMRepo = aTMRepo;
        }

        public bool Validate(long cardNumber, int pinCode)
        {
            ATM atm = _ATMRepo.RetrieveATM();
            return atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
        }
    }
}
