namespace Repository.DataAccess
{
    public class Card
    {
        public string Type { get; }
        public string BankName { get; }
        public int Id { get; }
        public string OwnerFullName { get; }
        public int Password { get; }

        public Card(string type, string bankName, int id, string ownerFullName, int password)
        {
            Type = type;
            BankName = bankName;
            Id = id;
            OwnerFullName = ownerFullName;
            Password = password;
        }
    }
}
