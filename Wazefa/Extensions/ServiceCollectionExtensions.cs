using Microsoft.EntityFrameworkCore;
using Wazefa.Core.ConfigurationDtos;
using Wazefa.Data;
using Wazefa.Services.AuthServices;
using Wazefa.Services.Mapping;
using Wazefa.Services.UserServices;

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
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAuthService, AuthService>()
                ;
        }
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<AuthSettings>(configuration.GetSection("AuthSetting"))
            ;
        }
    }
}
