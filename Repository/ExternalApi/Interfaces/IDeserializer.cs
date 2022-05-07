using Repository.DataAccess;

namespace Repository.ExternalApi.Interfaces
{
    public interface IDeserializer
    {
        public ATM DeserializeATM(string filePath);
    }
}
