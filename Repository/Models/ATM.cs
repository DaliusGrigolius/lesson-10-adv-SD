using System.Collections.Generic;

namespace Repository.DataAccess
{
    public class ATM
    {
        public int Id { get; }
        public List<Client> ClientsDataStorage { get; }

        public ATM(int id, List<Client> clientsDataStorage)
        {
            Id = id;
            ClientsDataStorage = clientsDataStorage;
        }
    }
}
