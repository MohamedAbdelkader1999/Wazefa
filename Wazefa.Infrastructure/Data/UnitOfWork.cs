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
        readonly IRepository<User, string> _userRepository;
        readonly IRepository<RefreshToken, string> _refreshTokenRepository;
        public UnitOfWork(WazefaContext wazefaContext)
        {
            _wazefaContext = wazefaContext;
            _userRepository = new Repository<User, string>(wazefaContext);
            _refreshTokenRepository = new Repository<RefreshToken, string>(wazefaContext);
        }
        IRepository<User, string> IUnitOfWork.userRepository => _userRepository;
        IRepository<RefreshToken, string> IUnitOfWork.refreshTokenRepository => _refreshTokenRepository;

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
