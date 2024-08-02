using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.DTOs.PaginationFilterDtos
{
    public class PaginationRequestDto<T>
    {
        public int PageIndex {  get; set; }
        public int PageSize {  get; set; }
        public bool IsAscending {  get; set; }
        public T Data {  get; set; } 
    }
}
