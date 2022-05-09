using Repository.DataAccess;
using Repository.ExternalApi;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMRepoTest
    {
        private readonly IATMRepo _repo;

        [Fact]
        public void ATMCheck_ReturnsNotNull()
        {
            Assert.NotNull(_repo.RetrieveATM());
        }
    }
}
