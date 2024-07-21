﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Domain.Entities;
using Wazefa.Infrastructure.EntityConfigurations;

namespace Wazefa.Infrastructure
{
    public class WazefaContext : IdentityDbContext<User,IdentityRole<string>, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public WazefaContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new SkillConfiguration().Configure(modelBuilder.Entity<Skill>());

        }
    }
}
