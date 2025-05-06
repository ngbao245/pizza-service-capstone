public class SpeedSmsService
{
    private readonly HttpClient _httpClient;
    private readonly string _accessToken;

    public SpeedSmsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _accessToken = "HTs1PjuDFfMsIakhp2B5YwWfW_Y52BdC";
    }

    public async Task<string> SendSmsAsync(string phone, string content, string sender = "")
    {
        var requestUrl = $"https://api.speedsms.vn/index.php/sms/send?" +
                         $"access-token={_accessToken}" +
                         $"&to={phone}" +
                         $"&content={Uri.EscapeDataString(content)}" +
                         $"&type=sms_type" +
                         $"&sender={sender}";

        var response = await _httpClient.GetAsync(requestUrl);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Lỗi khi gửi SMS: {response.StatusCode} - {responseContent}");

        return responseContent;
    }
}
