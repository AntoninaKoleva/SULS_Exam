using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
