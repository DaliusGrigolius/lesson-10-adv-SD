using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Repository.ExternalApi
{
    public class GetExternalData
    {
        public async Task<string> GetData(long cardNumber, int pinCode)
        {
            string baseURL = @$"https://localhost:44335/ATM?cardNumber={cardNumber}&pinCode={pinCode}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using Stream stream = response.GetResponseStream();
            using StreamReader reader = new(stream);
            return await reader.ReadToEndAsync();
        }
    }
}
