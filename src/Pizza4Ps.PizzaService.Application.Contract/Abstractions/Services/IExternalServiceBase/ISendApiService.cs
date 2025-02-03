namespace Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services.IExternalServiceBase
{
    public interface ISendApiService
    {
        Task<T?> SendRequestAsync<T>(
            HttpMethod method,
            string baseUrl,
            string endpoint,
            Dictionary<string, string>? queryParams = null,
            object? body = null,
            Dictionary<string, string>? headers = null);

        Task SendRequestWithoutResponseAsync(
            HttpMethod method,
            string baseUrl,
            string endpoint,
            Dictionary<string, string>? queryParams = null,
            object? body = null,
            Dictionary<string, string>? headers = null);
    }
}
