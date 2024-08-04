using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Data.MapperRelationShips
{
    public class MapperRelationships
    {
        public static void MapeRelationships(ModelBuilder builder)
        {
            builder.Entity<User>().HasOne(x => x.RefreshToken)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
