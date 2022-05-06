using System.Collections.Generic;

namespace Repository.DataAccess
{
    public class ATM
    {
        public int Id { get; }
        public List<Card> CardsList { get; }

        public ATM(int id, List<Card> cardsList)
        {
            Id = id;
            CardsList = cardsList;
        }
    }
}
