using Microsoft.EntityFrameworkCore;
using Wazefa.Core.Interfaces;
using Wazefa.Infrastructure.Data;
using Wazefa.Infrastructure.Services.Mapping;
using Wazefa.Infrastructure.Services.UserService;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWorkAndRepository(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<,>),typeof(Repository<,>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
        
        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<WazefaContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(typeof(MappingProfile));
        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services
                .AddScoped<IUserService,UserService>();
        }
    }
}
