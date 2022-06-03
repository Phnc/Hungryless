using Hungryless.Domain.Contracts.Repository;
using Hungryless.Domain.Contracts.Services;
using Hungryless.Domain.Services;
using Hungryless.Infrastructure.Context;
using Hungryless.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hungryless.Infrastructure
{
    public static class ConfigureDepedencies
    {
        public static void AddHungrylessDepedencies(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<HungrylessDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SuppliesDB")));

            service.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            service.AddScoped<IRepositorySupplies, SuppliesRepository>();
            service.AddScoped(typeof(IServiceBase<>), typeof(BaseService<>));
            service.AddScoped<ISuppliesService, SuppliesService>();
        }
    }
}
