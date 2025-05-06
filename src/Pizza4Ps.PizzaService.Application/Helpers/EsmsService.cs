using Microsoft.Extensions.Configuration;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class EsmsService
{
    private readonly HttpClient _http;
    private readonly string _endpoint, _apiKey, _secretKey;

    public EsmsService(HttpClient http, IConfiguration cfg)
    {
        _http = http;
        _endpoint = cfg["ESMS:Endpoint"];
        _apiKey = cfg["ESMS:ApiKey"];
        _secretKey = cfg["ESMS:SecretKey"];
    }

    public async Task<EsmsResponse> SendTestOtpAsync(string phone, string code)
    {
        var payload = new
        {
            ApiKey = _apiKey,
            SecretKey = _secretKey,
            Phone = phone,
            Content = $"{code} la ma xac minh dang ky Baotrixemay cua ban",
            Brandname = "Baotrixemay",
            SmsType = "2",
            IsUnicode = "0",
            campaignid = "Cảm ơn sau mua hàng tháng 7",
            RequestId = Guid.NewGuid().ToString(),
            CallbackUrl = "https://esms.vn/webhook/"
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var resp = await _http.PostAsync(_endpoint, content);
        resp.EnsureSuccessStatusCode();

        var response = await resp.Content.ReadFromJsonAsync<EsmsResponse>();
        return response!;
    }
}
