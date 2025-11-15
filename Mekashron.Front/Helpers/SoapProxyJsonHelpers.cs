using System;
using Mekashron.Front.Models;

namespace Mekashron.Front.Helpers;

public static class SoapProxyJsonHelpers
{

    public static UserData? ExtractUserDataJson(this string jsonResponse)
    {
        try
        {
            var proxyResponse = System.Text.Json.JsonSerializer.Deserialize<SoapProxyResponse>(jsonResponse);
            
            if (proxyResponse?.Ret == null)
            {
                Console.WriteLine("No 'ret' field in response");
                return null;
            }
            
            var userData = System.Text.Json.JsonSerializer.Deserialize<UserData>(proxyResponse.Ret.Trim());
        
            if (userData?.IsValid == true)
            {
                return userData;
            }
            
            Console.WriteLine("Invalid user data");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
            return null;
        }
    }
}
