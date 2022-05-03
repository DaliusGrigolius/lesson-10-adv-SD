using BusinessLogic.Interfaces;
using Repository.DataAccess;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class ATMService : IATMService
    {
        private readonly IATMRepo _ATMRepo;
        public ATMService(IATMRepo aTMRepo)
        {
            _ATMRepo = aTMRepo;
            //_privateProperty = new ATMController();
        }

        public bool Validate(int cardNumber, int password)
        {
            return true;
        }

        public List<ATM> Test(int cardNumber, int password)
        {
            return _ATMRepo.ReturnATMList();
        }
    }
}
