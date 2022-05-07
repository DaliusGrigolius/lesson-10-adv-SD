using Repository.DataAccess;
using Repository.ExternalApi.Interfaces;
using System.IO;
using System.Text.Json;

namespace Repository.ExternalApi
{
    public class Deserializer : IDeserializer
    {
        public ATM DeserializeATM(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ATM jsonData = JsonSerializer.Deserialize<ATM>(jsonString, options);

            return jsonData;
        }
    }
}
