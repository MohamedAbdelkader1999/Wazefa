using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.DTOs.AuthDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;

namespace Wazefa.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ResponseResultDto<LoginResponseDto>> SignInAsync(LoginRequestDto dto);
    }
}
