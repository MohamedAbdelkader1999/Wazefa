using API.CustomExceptionMiddleware;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Wazefa.Core.ConfigurationDtos;
using Wazefa.Data;
using Wazefa.Services.AppointmentServices;
using Wazefa.Services.AuthServices;
using Wazefa.Services.CompanyServices;
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
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IAppointmentService, AppointmentService>()
                ;
        }
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<AuthSettings>(configuration.GetSection("AuthSetting"))
            ;
        }
        public static IServiceCollection ConfigureLoggerService(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager, LoggerManager>();
        
        //public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        //    => app.UseMiddleware<ExceptionMiddleware>();
        

    }
}
