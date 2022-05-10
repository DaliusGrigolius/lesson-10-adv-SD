using Repository.ExternalApi.Interfaces;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        private ATM Atm { get; }

        public ATMRepo(IDeserializer _deserializer, string filePath)
        {
            Atm = _deserializer.DeserializeATM(filePath);
        }

        public ATM RetrieveATM()
        {
            return Atm;
        }
    }
}