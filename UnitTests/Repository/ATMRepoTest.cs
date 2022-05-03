using Controllers.Controllers;
using Repository.DataAccess;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMRepoTest
    {
        private readonly IATMRepo _ATMRepo;
        public ATMRepoTest(IATMRepo aTMRepo)
        {
            _ATMRepo = aTMRepo;
            //_privateProperty = new ATMController();
        }

        //[Fact]
        //public void ATMListCheckIfReturnMoreThanOne()
        //{
        //    Assert.True(_ATMRepo.ReturnATMList().Count > 0);
        //}
    }
}
