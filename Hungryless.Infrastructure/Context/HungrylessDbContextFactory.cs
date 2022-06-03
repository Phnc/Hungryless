using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hungryless.Infrastructure.Context
{
    public class HungrylessDbContextFactory : IDesignTimeDbContextFactory<HungrylessDbContext>
    {
        public HungrylessDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HungrylessDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=suppliesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new HungrylessDbContext(optionsBuilder.Options);
        }
    }
}
