using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Infrastructure.Data;

namespace Wazefa.Infrastructure.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder builder)
        {
            using IServiceScope scope = builder.ApplicationServices.CreateScope();
            using WazefaContext context = scope.ServiceProvider.GetRequiredService<WazefaContext>();
            context.Database.Migrate();
        }
    }
}
