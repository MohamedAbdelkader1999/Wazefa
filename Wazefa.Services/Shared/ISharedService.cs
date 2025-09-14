using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Services.Shared
{
    public interface ISharedService
    {
        string HashPassword(User user, string password);
        PasswordVerificationResult VerifyPassword(User user, string password);
    }
}
