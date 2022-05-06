using Repository.ExternalApi;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        Deserializer Deserializer = new Deserializer();
        private ATM atm { get; }

        public ATMRepo()
        {
            atm = Deserializer.DeserializeATM();
        }

        public ATM RetrieveATM()
        {
            return atm;
        }
    }
}