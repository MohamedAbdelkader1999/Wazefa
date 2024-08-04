using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Data
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
        IRepository<User, string> userRepository { get; }
        IRepository<RefreshToken, string> refreshTokenRepository { get; }
    }
}
