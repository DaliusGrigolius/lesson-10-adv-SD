using Repository.Models;
using System.Collections.Generic;

namespace Repository.DataAccess
{
    public class Card
    {
        public long Id { get; }
        public int PinCode { get; }
        public Client Client { get; }
        public List<Transaction> TransactionList { get; }
        public double Balance { get; set; }

        public Card(long id, int pinCode, Client client, List<Transaction> transactionList, double balance)
        {
            Id = id;
            Client = client;
            PinCode = pinCode;
            Balance = balance;
            TransactionList = transactionList;
        }
    }
}
