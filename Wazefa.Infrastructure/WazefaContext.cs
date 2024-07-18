using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Domain.Entities;

namespace Wazefa.Infrastructure
{
    public class WazefaContext : IdentityDbContext<User<int>,IdentityRole<int>,int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public WazefaContext(DbContextOptions options) : base(options)
        {
        }
    }
}
