using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Interfaces
{
    public interface IBaseService<T, ADDDTO,UPDATEDTO,OUTPUTDTO,Key>
        where T : class 
        where ADDDTO: class
        where UPDATEDTO: class
        where OUTPUTDTO : class
    {
        Task<OUTPUTDTO> AddAsync(ADDDTO obj);
        OUTPUTDTO Update(UPDATEDTO obj);
        void DeleteAsync(T entity);
        Task<OUTPUTDTO> GetByIdAsync(Key Id);
    }
}
