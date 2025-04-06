using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;

namespace Wazefa.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WazefaContext _wazefaContext;
        readonly IRepository<User, string> _userRepository;
        readonly IRepository<RefreshToken, string> _refreshTokenRepository;
        readonly IRepository<Company, string> _companyRepository;
        readonly IRepository<Appointment, string> _appointmentRepository;
        public UnitOfWork(WazefaContext wazefaContext)
        {
            _wazefaContext = wazefaContext;
            _userRepository = new Repository<User, string>(wazefaContext);
            _refreshTokenRepository = new Repository<RefreshToken, string>(wazefaContext);
            _companyRepository = new Repository<Company, string>(wazefaContext);
            _appointmentRepository = new Repository<Appointment, string>(wazefaContext);
        }
        IRepository<User, string> IUnitOfWork.userRepository => _userRepository;
        IRepository<RefreshToken, string> IUnitOfWork.refreshTokenRepository => _refreshTokenRepository;
        IRepository<Company, string> IUnitOfWork.companyRepository => _companyRepository;
        IRepository<Appointment, string> IUnitOfWork.appointmentRepository => _appointmentRepository;

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
