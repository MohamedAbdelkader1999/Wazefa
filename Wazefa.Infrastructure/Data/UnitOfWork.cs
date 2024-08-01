using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;
using Wazefa.Core.Interfaces;

namespace Wazefa.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WazefaContext _wazefaContext;
        readonly IRepository<User> _userRepository;
        readonly IRepository<RefreshToken> _refreshTokenRepository;
        public UnitOfWork(WazefaContext wazefaContext)
        {
            _wazefaContext = wazefaContext;
            _userRepository = new Repository<User>(wazefaContext);
            _refreshTokenRepository = new Repository<RefreshToken>(wazefaContext);
        }
        IRepository<User> IUnitOfWork.userRepository => _userRepository;
        IRepository<RefreshToken> IUnitOfWork.refreshTokenRepository => _refreshTokenRepository;

        public int Save()
        {
            return _wazefaContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _wazefaContext.SaveChangesAsync();
        }
    }
}
