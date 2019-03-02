using System.Diagnostics;
using System.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinTVNews
{
    public class SimpleHttpClient
    {
        async public Task<JsonArray> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();


                    return (JsonArray)JsonValue.Parse(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine("\nException Caught!");
                    Debug.WriteLine("Message :{0} ", e.Message);
                }

                return null;
            }
        }
    }
}
