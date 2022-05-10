using Repository.DataAccess;
using Repository.ExternalApi;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMServiceTest
    {
        readonly ATMRepo repo;
        public ATMServiceTest()
        {
            repo = new ATMRepo(new Deserializer(), @"..\..\..\..\DataFiles\atm.json");
        }

        [Fact]
        public void Validate_CheckDataFile_ReturnsFalse()
        {
            long cardNumber = 1234123412341234;
            int pinCode = 1232;
            ATM atm = repo.RetrieveATM();
            bool actual = atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
            var expected = false;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Validate_CheckDataFile_ReturnsTrue()
        {
            long cardNumber = 1111222233334444;
            int pinCode = 1234;
            ATM atm = repo.RetrieveATM();
            bool actual = atm.CardsList.Exists(i => i.Id == cardNumber && i.PinCode == pinCode);
            var expected = true;
            Assert.Equal(expected, actual);
        }
    }
}
