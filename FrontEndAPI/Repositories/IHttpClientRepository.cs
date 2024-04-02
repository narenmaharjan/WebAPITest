namespace FrontEndApi.Repositories
{
    public interface IHttpClientRepository
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, string data);

    }
}
