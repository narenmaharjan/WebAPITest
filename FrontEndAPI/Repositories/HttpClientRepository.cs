namespace FrontEndApi.Repositories
{
    public class HttpClientRepository : IHttpClientRepository
    {
        private readonly HttpClient _httpClient;

        public HttpClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
           return _httpClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url, string data)
        {
            return _httpClient.PostAsync(url, new StringContent(data));
        }

       
    }
}
