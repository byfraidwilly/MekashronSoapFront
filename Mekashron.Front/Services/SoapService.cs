using Mekashron.Front.Helpers;
using Mekashron.Front.Models;

namespace Mekashron.Front.Services;

public class SoapService : ISoapService
{
    private readonly ILogger<SoapService> _logger;

    private const string SOAP_URL = "http://isapi.mekashron.com/soapclient/soapclient.php?URL=http://isapi.mekashron.com/icu-tech/icutech-test.dll%2Fwsdl%2FIICUTech";
    
    private const string WSDL_URL = "http://isapi.mekashron.com/icu-tech/icutech-test.dll/wsdl/IICUTech";


    private readonly HttpClient _httpClient;
    public SoapService(ILogger<SoapService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
        AddHeaders();
    }


    private void AddHeaders()
    {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
            _httpClient.DefaultRequestHeaders.Add("Origin", "http://isapi.mekashron.com");
            _httpClient.DefaultRequestHeaders.Add("Referer", "http://isapi.mekashron.com/soapclient/soapclient.php");
            _httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
    }

    public async Task<UserData?> LoginAsync(string email, string password)
    {
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "URL", WSDL_URL },
                { "func", "Login" },
                { "params", $"UserName={Uri.EscapeDataString(email)}&Password={Uri.EscapeDataString(password)}&IPs=" }
            };

            var content = new FormUrlEncodedContent(formData);

            var response = await _httpClient.PostAsync(SOAP_URL, content);
            var responseText = await response.Content.ReadAsStringAsync();

            return responseText.ExtractUserDataJson();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during SOAP login");
            return null;
        }
    }
}
