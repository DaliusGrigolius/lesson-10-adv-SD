using Repository.DataAccess;
using Repository.ExternalApi;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMRepoTest
    {
        readonly ATMRepo repo;

        public ATMRepoTest()
        {
            repo = new ATMRepo(new Deserializer(), @"..\..\..\..\DataFiles\atm.json");
        }

        [Fact]
        public void RetrieveATM_ReturnsNotNull()
        {
            Assert.NotNull(repo.RetrieveATM());
        }
    }
}
