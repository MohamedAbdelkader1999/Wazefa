using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;
using Wazefa.Data.EntityConfigurations;

namespace Wazefa.Data
{
    public class WazefaContext : IdentityDbContext<User>
    {
        public WazefaContext(DbContextOptions<WazefaContext> options) : base(options)
        {

        }
        //public new DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new RefreshTokenConfiguration().Configure(modelBuilder.Entity<RefreshToken>());
            new CompanyConfiguration().Configure(modelBuilder.Entity<Company>());
            new AppointmentConfiguration().Configure(modelBuilder.Entity<Appointment>());
            base.OnModelCreating(modelBuilder);

        }
    }
}
