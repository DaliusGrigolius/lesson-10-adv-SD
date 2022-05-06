using Repository.DataAccess;
using System.IO;
using System.Text.Json;

namespace Repository.ExternalApi
{
    public class Serializer
    {
        private readonly ATMRepo ATMRepo;

        public Serializer()
        {
            ATMRepo = new ATMRepo();
        }

        public void GenerateDataFile()
        {
            var atm = ATMRepo.RetrieveATM();
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(atm, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void UpdateDataFile(ATM atm)
        {
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(atm, options);
            File.WriteAllText(filePath, jsonString);
        }

    }
}
