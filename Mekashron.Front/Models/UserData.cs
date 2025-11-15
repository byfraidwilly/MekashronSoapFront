using System.Text.Json.Serialization;

namespace Mekashron.Front.Models;

public class UserData
{
    
    [JsonPropertyName("EntityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("LastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("Company")]
    public string Company { get; set; } = string.Empty;

    [JsonPropertyName("Address")]
    public string Address { get; set; } = string.Empty;

    [JsonPropertyName("City")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("Country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("Zip")]
    public string Zip { get; set; } = string.Empty;

    [JsonPropertyName("Phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonPropertyName("Mobile")]
    public string Mobile { get; set; } = string.Empty;

    [JsonPropertyName("Email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("EmailConfirm")]
    public int EmailConfirm { get; set; }

    [JsonPropertyName("MobileConfirm")]
    public int MobileConfirm { get; set; }

    [JsonPropertyName("CountryID")]
    public int CountryID { get; set; }

    [JsonPropertyName("Status")]
    public int Status { get; set; }

    [JsonPropertyName("lid")]
    public string SessionId { get; set; } = string.Empty;

    [JsonPropertyName("FTPHost")]
    public string FTPHost { get; set; } = string.Empty;

    [JsonPropertyName("FTPPort")]
    public int FTPPort { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim();

    public bool IsValid => EntityId > 0 && !string.IsNullOrEmpty(Email);
}
