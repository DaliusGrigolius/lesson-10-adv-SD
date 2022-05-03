using System.Collections.Generic;

namespace Repository.DataAccess
{
    public interface IATMRepo
    {
        public List<ATM> ReturnATMList();
    }
}
