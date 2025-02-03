using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services.IExternalServiceBase;
using System.Text;
using System.Text.Json;

namespace Pizza4Ps.PizzaService.Infrastructure.Services.ExternalServiceBase
{
    public class SendApiService : ISendApiService
    {
        private readonly HttpClient _httpClient;

        public SendApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> SendRequestAsync<T>(
            HttpMethod method,
            string baseUrl,
            string endpoint,
            Dictionary<string, string>? queryParams = null,
            object? body = null,
            Dictionary<string, string>? headers = null)
        {
            var url = $"{baseUrl}{endpoint}";

            // Xây dựng URL với query parameters
            if (queryParams != null && queryParams.Any())
            {
                url += "?" + string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
            }

            // Tạo HttpRequestMessage
            var request = new HttpRequestMessage(method, url);

            // Gắn body nếu có
            if (body != null)
            {
                request.Content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    "application/json"
                );
            }

            // Gắn headers nếu có
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            // Gửi request
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Đọc và deserialize kết quả
            var responseJson = await response.Content.ReadAsStringAsync();
            //var test = JsonSerializer.Deserialize<T>(responseJson);
            //var test1 = JsonSerializer.Deserialize<BaseResponseDto<DeviceStatusDto>>(responseJson);

            return JsonSerializer.Deserialize<T>(responseJson);
        }

        public async Task SendRequestWithoutResponseAsync(
            HttpMethod method,
            string baseUrl,
            string endpoint,
            Dictionary<string, string>? queryParams = null,
            object? body = null,
            Dictionary<string, string>? headers = null)
        {
            // Gọi SendRequestAsync với T là object
            await SendRequestAsync<object>(method, baseUrl, endpoint, queryParams, body, headers);
        }
    }
}
