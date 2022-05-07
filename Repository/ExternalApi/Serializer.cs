using Repository.DataAccess;
using Repository.ExternalApi.Interfaces;
using System.IO;
using System.Text.Json;

namespace Repository.ExternalApi
{
    public class Serializer : ISerializer
    {
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
