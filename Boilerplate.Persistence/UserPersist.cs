using Boilerplate.Domain;
using Boilerplate.Persistence.Context;
using Boilerplate.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Persistence
{
    public class UserPersist : IUserPersist
    {
        private readonly BoilerplateContext _context;
        public UserPersist(BoilerplateContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<User[]> GetAllUserAsync()
        {
            IQueryable<User> query = _context.Users;
            query = query.OrderBy(user => user.Id);
            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            IQueryable<User> query = _context.Users;
            var userFind = query.Where(user => user.UserName == username);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            IQueryable<User> query = _context.Users;
            var userFind = query.Where(user => user.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
