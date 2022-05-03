using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClient
    {
        int Id { get; }
        string FullName { get; }
        string BirthDate { get; }
        string Address { get; }
        string PhoneNumber { get; }
        string Email { get; }
    }
}
