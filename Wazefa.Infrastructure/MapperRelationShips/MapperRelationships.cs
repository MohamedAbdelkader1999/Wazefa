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
        public static void MapRelationships(ModelBuilder builder)
        {
            builder.Entity<User>().HasOne(x => x.RefreshToken)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>().HasOne(x => x.CreatedByUser)
                .WithMany(c => c.Companies).HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Appointment>().HasOne(x => x.Company)
                .WithMany(x=>x.Appointments).IsRequired().HasForeignKey(x=>x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>().HasMany(x => x.Appointments)
               .WithOne(x => x.CreatedByUser).HasForeignKey(x => x.CreatedByUserId)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
