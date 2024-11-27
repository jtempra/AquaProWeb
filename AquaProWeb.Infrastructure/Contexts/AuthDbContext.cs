using AquaProWeb.Common.Authentication;
using AquaProWeb.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaProWeb.Infrastructure.Contexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<Register> Registration { get; set; } = default!;
        public DbSet<TokenInfo> TokenInfo { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;
    }
}
