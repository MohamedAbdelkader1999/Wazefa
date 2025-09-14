using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Services.Shared
{
    public class SharedService(PasswordHasher<User> hasher) : ISharedService
    {
        public string HashPassword(User user,string password)
        {
            return hasher.HashPassword(user, password); 
        }
        public PasswordVerificationResult VerifyPassword(User user, string password)
        {
            return hasher.VerifyHashedPassword(user, user.Password, password);
        }

    }
}
