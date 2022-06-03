using Hungryless.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hungryless.Infrastructure.Context
{
    public class HungrylessDbContext : DbContext
    {
        public HungrylessDbContext(DbContextOptions<HungrylessDbContext> options) : base(options)
        {
        }

        public DbSet<Supplies>? Supplies { get; set; }
    }
}
