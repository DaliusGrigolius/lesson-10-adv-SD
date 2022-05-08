using Repository.ExternalApi;

namespace Repository.DataAccess
{
    public class ATMRepo : IATMRepo
    {
        private readonly Deserializer Deserializer;
        private ATM Atm { get; }

        public ATMRepo(Deserializer deserializer)
        {
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            Deserializer = deserializer;
            Atm = Deserializer.DeserializeATM(filePath);
        }

        public ATM RetrieveATM()
        {
            return Atm;
        }
    }
}