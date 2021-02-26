using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Terabaitas.Core.Domain;
using Terabaitas.Data.Entities;

namespace Terabaitas.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<ShopItemEntity> ShopItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
