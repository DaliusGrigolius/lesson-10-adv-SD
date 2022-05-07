using Repository.ExternalApi;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        private readonly Deserializer Deserializer;
        private ATM atm { get; }

        public ATMRepo(Deserializer deserializer)
        {
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            Deserializer = deserializer;
            atm = Deserializer.DeserializeATM(filePath);
        }

        public ATM RetrieveATM()
        {
            return atm;
        }
    }
}