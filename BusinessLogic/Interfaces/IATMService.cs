using Repository.DataAccess;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IATMService
    {
        public bool Validate(int cardNumber, int password);
        public List<ATM> Test(int cardNumber, int password);
    }
}
