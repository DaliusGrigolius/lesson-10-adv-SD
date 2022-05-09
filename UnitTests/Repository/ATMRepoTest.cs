using Controllers.Controllers;
using Repository.DataAccess;
using System;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMRepoTest
    {
        private readonly IATMRepo _ATMRepo;
        public ATMRepoTest(IATMRepo aTMRepo)
        {
            _ATMRepo = aTMRepo;
        }

        [Fact]
        public void ATMCheck_ReturnsATM()
        {
            Assert.NotNull(_ATMRepo.RetrieveATM());
        }
    }
}
