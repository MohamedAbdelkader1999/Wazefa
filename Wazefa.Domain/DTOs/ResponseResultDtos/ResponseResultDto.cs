using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.DTOs.ResponseResultDtos
{
    public class ResponseResultDto<T>
    {
        public int StatusCode {  get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public ResponseResultDto<T> MappingResponse()
        {
            this.StatusCode = (int)HttpStatusCode.NotFound;
            return this;
        }
        public ResponseResultDto<T> MappingResponse(int statusCode)
        {
            this.StatusCode = statusCode;
            return this;
        }
        public ResponseResultDto<T> MappingResponse(T data)
        {
            this.StatusCode = (int)HttpStatusCode.OK;
            this.Data = data;
            return this;
        }
        public ResponseResultDto<T> MappingResponse(int statusCode,string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            return this;
        }
        public ResponseResultDto<T> MappingResponse(string message)
        {
            this.StatusCode = (int)HttpStatusCode.BadRequest;
            this.Message = message;
            return this;
        }
    }
}
