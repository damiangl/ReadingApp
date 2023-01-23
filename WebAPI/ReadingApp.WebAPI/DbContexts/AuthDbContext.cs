using Microsoft.EntityFrameworkCore;
using ReadingApp.Infrastructure.Entities;

namespace ReadingApp.WebAPI.DbContexts
{
    public class AuthDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}
