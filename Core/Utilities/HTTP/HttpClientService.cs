using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.HTTP
{
    public class HttpClientService : IDisposable
    {
        private static HttpClient client = new HttpClient();
        private static AuthenticationHeaderValue authenticationHearderValue;
        public HttpClientService(string userName, string password)
        {
            var authToken = Encoding.ASCII.GetBytes($"{userName}:{password}");
            authenticationHearderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<string> GetRequest(string apiURL)
        {
            client.DefaultRequestHeaders.Authorization = authenticationHearderValue;
            var result = await client.GetAsync(apiURL);
            return await result.Content.ReadAsStringAsync();
        }



    }
}
