using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Core.Interfaces
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
        IRepository<User> userRepository { get; }
        IRepository<RefreshToken> refreshTokenRepository { get; }
    }
}
