using Boilerplate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User model);
        Task<User> UpdateUser(User model, int userId);
        Task<bool> DeleteUser(int userId);
        Task<User[]> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);
    }
}
