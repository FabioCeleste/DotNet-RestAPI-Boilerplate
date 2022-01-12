using Boilerplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Persistence.Context
{
    public class BoilerplateContext : DbContext
    {
        public BoilerplateContext(DbContextOptions<BoilerplateContext> options) : base (options) { }
        public DbSet<User> Users { get; set; }
    }
}