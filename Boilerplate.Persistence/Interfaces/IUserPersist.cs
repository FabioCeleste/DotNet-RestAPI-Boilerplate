using Boilerplate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Persistence.Interfaces
{
    public interface IUserPersist
    {
        Task<User[]> GetAllUserAsync();
        Task<User> GetUserByNameAsync(string username);
        Task<User> GetUserByIdAsync(int id);
    }
}
