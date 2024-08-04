using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.ResponseResultDtos
{
    public class ResponseResultDto<T>
    {
        public int statusCode {  get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public ResponseResultDto<T> MappingResponse()
        {
            return new ResponseResultDto<T>() { statusCode = 404 };
        }
        public ResponseResultDto<T> MappingResponse(int statusCode)
        {
            return new ResponseResultDto<T>() { statusCode = statusCode };
        }
        public ResponseResultDto<T> MappingResponse(T data)
        {
            return new ResponseResultDto<T>() { statusCode = 200,Data = data };
        }
        public ResponseResultDto<T> MappingResponse(int statusCode,string message)
        {
            return new ResponseResultDto<T>() { statusCode = statusCode ,Message = message};
        }
        public ResponseResultDto<T> MappingResponse(string message)
        {
            return new ResponseResultDto<T>() { statusCode = 400 ,Message = message};
        }
    }
}
