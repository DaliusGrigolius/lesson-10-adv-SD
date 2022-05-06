using Repository.DataAccess;
using System.IO;
using System.Text.Json;

namespace Repository.ExternalApi
{
    public class Deserializer
    {
        public ATM DeserializeATM()
        {
            var filePath = @"..\..\..\..\DataFiles\atm.json";
            var jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ATM jsonData = JsonSerializer.Deserialize<ATM>(jsonString, options);

            return jsonData;
        }
    }
}
