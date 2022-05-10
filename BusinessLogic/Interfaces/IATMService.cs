using Repository.DataAccess;

namespace BusinessLogic.Interfaces
{
    public interface IATMService
    {
        public bool Validate(long cardNumber, int pinCode, ATM atm);
    }
}
