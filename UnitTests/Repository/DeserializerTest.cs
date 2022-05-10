using Repository.DataAccess;
using Repository.ExternalApi;
using Xunit;

namespace UnitTests.Repository
{
    public class DeserializerTest
    {
        readonly ATMRepo repo;

        public DeserializerTest()
        {
            repo = new ATMRepo(new Deserializer(), @"..\..\..\..\DataFiles\atm.json");
        }
        [Fact]
        public void DeserializeATM_DataFile_ReturnsATMTypeObject()
        {
            var atm = repo.RetrieveATM();
            Assert.IsType<ATM>(atm);
        }
    }
}
