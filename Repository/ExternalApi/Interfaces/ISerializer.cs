using Repository.DataAccess;

namespace Repository.ExternalApi.Interfaces
{
    public interface ISerializer
    {
        public void UpdateDataFile(ATM atm, string filePath);
    }
}
