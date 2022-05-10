using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Repository
{
    public class ATMTest
    {
        [Fact]
        public void CreateATM_DataValid_ATMCreated()
        {
            List<Transaction> transactionList = new List<Transaction>()
            {
                new Transaction(1, "a", "b", 50, "c", "d"),
            };

            Client client = new Client(1, "a", "b", "c", "d", "e");

            List<Card> cardList = new List<Card>()
            {
                new Card(1234123412341234, 4234, client, transactionList, 100.00),
            };

            ATM atm = new ATM(1, cardList);

            Assert.Equal(1, atm.Id);
            Assert.Equal(1234123412341234, atm.CardsList[0].Id);
            Assert.Equal(4234, atm.CardsList[0].PinCode);
            Assert.Equal(100, atm.CardsList[0].Balance);
            Assert.Equal(1, atm.CardsList[0].TransactionList[0].Id);
            Assert.Equal("a", atm.CardsList[0].TransactionList[0].Executor);
            Assert.Equal("b", atm.CardsList[0].TransactionList[0].DateOfEvent);
            Assert.Equal(50, atm.CardsList[0].TransactionList[0].Amount);
            Assert.Equal("c", atm.CardsList[0].TransactionList[0].Purpose);
            Assert.Equal("d", atm.CardsList[0].TransactionList[0].Status);
            Assert.Equal(1, atm.CardsList[0].Client.Id);
            Assert.Equal("a", atm.CardsList[0].Client.FullName);
            Assert.Equal("b", atm.CardsList[0].Client.BirthDate);
            Assert.Equal("c", atm.CardsList[0].Client.Address);
            Assert.Equal("d", atm.CardsList[0].Client.PhoneNumber);
            Assert.Equal("e", atm.CardsList[0].Client.Email);
        }
    }
}
