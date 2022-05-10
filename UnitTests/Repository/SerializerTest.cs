using Repository.DataAccess;
using Repository.ExternalApi;
using System;
using System.IO;
using System.Text.Json;
using Xunit;

namespace UnitTests.Repository
{
    public class SerializerTest
    {
        readonly string filePath;
        readonly ATMRepo repo;
        readonly ATM atm;

        public SerializerTest()
        {
            filePath = @"..\..\..\..\DataFiles\atm.json";
            repo = new ATMRepo(new Deserializer(), filePath);
            atm = repo.RetrieveATM();
        }

        [Fact]
        public void UpdateDataFile_DataFileModify_TimeChanged()
        {
            DateTime lastModification = File.GetLastWriteTime(filePath);
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(atm, options);
            File.WriteAllText(filePath, jsonString);

            DateTime newModification = File.GetLastWriteTime(filePath);
            
            Assert.NotEqual(lastModification, newModification);
        }
    }
}
