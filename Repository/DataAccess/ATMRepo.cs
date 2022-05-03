using System.Collections.Generic;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        public List<ATM> ReturnATMList()
        {
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client(1, "a", "1999", "address1", "86548894", "@gmail"));
            List<ATM> atmList = new List<ATM>();
            atmList.Add(new ATM(1, clientList));
            return atmList;
        }
    }
}
