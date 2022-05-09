using Repository.ExternalApi;
using Repository.ExternalApi.Interfaces;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        private readonly IDeserializer _deserializer;
        private ATM Atm { get; }

        public ATMRepo(IDeserializer deserializer)
        {
            _deserializer = deserializer;
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            Atm = _deserializer.DeserializeATM(filePath);
        }

        public ATM RetrieveATM()
        {
            return Atm;
        }
    }
}