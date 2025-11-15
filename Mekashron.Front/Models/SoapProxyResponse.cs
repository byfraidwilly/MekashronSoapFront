using System;
using System.Text.Json.Serialization;

namespace Mekashron.Front.Models;

public class SoapProxyResponse
{
    [JsonPropertyName("request")]
    public string? Request { get; set; }

    [JsonPropertyName("response")]
    public string? Response { get; set; }

    [JsonPropertyName("ret")]
    public string? Ret { get; set; }
}
