using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Application.Interfaces.Services;
using HumanGuide.Infrastructure.Persistence.Implementations;
using HumanGuide.Infrastructure.Persistence.Implementations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumanGuide.Infrastructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IImageService, ImageService>();

        }
    }
}
