namespace Repository.DataAccess 
{ 
    public class Client
    {
        public int Id { get; }
        public string FullName { get; }
        public string BirthDate { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        public Client(int id, string fullName, string birthDate, string address, string phoneNumber, string email)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
