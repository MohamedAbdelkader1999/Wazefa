using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Entities;
using Wazefa.Core.Interfaces;

namespace Wazefa.Infrastructure.Services
{
    public class BaseService<T,ADDDTO , UPDATEDTO, OUTPUTDTO, Key> 
        : IBaseService<T,ADDDTO, UPDATEDTO, OUTPUTDTO, Key>
        where T : class
        where ADDDTO : class
        where UPDATEDTO : class
        where OUTPUTDTO : class
    {
        private readonly IRepository<T, Key> _repository;
        private readonly IMapper _mapper;
        public BaseService(IRepository<T, Key> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OUTPUTDTO> AddAsync(ADDDTO obj)
        {
            var result = await _repository.AddAsync(_mapper.Map<T>(obj));
            return _mapper.Map<OUTPUTDTO>(result);
        }

        public void DeleteAsync(T entity)
        {
            _repository.Delete(entity);
        }

        public async Task<OUTPUTDTO> GetByIdAsync(Key Id)
        {
            var entity = await _repository.GetByIdAsync(Id);
            return _mapper.Map<OUTPUTDTO>(entity);
        }

        public OUTPUTDTO Update(UPDATEDTO obj)
        {
            var result = _repository.Update(_mapper.Map<T>(obj));
            return _mapper.Map<OUTPUTDTO>(result);
        }
    }
}
