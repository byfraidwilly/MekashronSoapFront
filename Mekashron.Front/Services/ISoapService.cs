using Mekashron.Front.Models;

namespace Mekashron.Front.Services;

public interface ISoapService
{
   Task<UserData?> LoginAsync(string email, string password);
}
