using Repository.DataAccess;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMServiceTest
    {
        private readonly IATMRepo _repo;

        [Fact]
        public void ValidateInput_CheckDataFile_ReturnsFalse()
        {
            long cardNumber = 1234123412341234;
            int pinCode = 1232;
            ATM atm = _repo.RetrieveATM();
            bool actual = atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
            var expected = false;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateInput_CheckDataFile_ReturnsTrue()
        {
            long cardNumber = 1111222233334444;
            int pinCode = 1234;
            ATM atm = _repo.RetrieveATM();
            bool actual = atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
            var expected = true;
            Assert.Equal(expected, actual);
        }
    }
}
