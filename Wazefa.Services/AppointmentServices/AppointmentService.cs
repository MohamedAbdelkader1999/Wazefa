using AutoMapper;
using Wazefa.Core.DTOs.AppointmentDtos;
using Wazefa.Core.DTOs.ResponseResultDtos;
using Wazefa.Core.Entities;
using Wazefa.Data;

namespace Wazefa.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResultDto<AppointmentResponse>> AddAsync(AddAppointmentRequest dto,string userId)
        {
            ResponseResultDto<AppointmentResponse> response = new();
            Appointment entity = _mapper.Map<Appointment>(dto);
            User? loggedInUser = await _unitOfWork.userRepository.GetByIdAsync(userId);
            if (loggedInUser == null)
                return response.MappingResponse();
            entity.CreatedByUserId = userId;
            entity.CompanyId = loggedInUser.CompanyId;
            Appointment? result = await _unitOfWork.appointmentRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return response.MappingResponse(_mapper.Map<AppointmentResponse>(result));
        }
        public async Task<ResponseResultDto<AppointmentResponse>> GetByIdAsync(string id)
        {
            var response = new ResponseResultDto<AppointmentResponse>();
            Appointment? appointment = await _unitOfWork.appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                return response.MappingResponse();
            return response.MappingResponse(_mapper.Map<AppointmentResponse>(appointment));
        }
        public async Task<ResponseResultDto<AppointmentResponse>> UpdateAsync(UpdateAppointmentRequest dto,string userId)
        {
            var response = new ResponseResultDto<AppointmentResponse>();
            Appointment? entity = await _unitOfWork.appointmentRepository.GetByIdAsync(dto.Id);
            User? loggedInUser = await _unitOfWork.userRepository.GetByIdAsync(userId);
            if (entity == null || loggedInUser == null)
                return response.MappingResponse();
            _mapper.Map(dto, entity);
            entity.ModificationDate = DateTime.UtcNow;
            Appointment updatedentity = _unitOfWork.appointmentRepository.Update(entity);
            return response.MappingResponse(_mapper.Map<AppointmentResponse>(updatedentity));
        }
        public async Task<ResponseResultDto<bool>> DeleteAsync(string id)
        {
            var response = new ResponseResultDto<bool>();
            Appointment? entity = await _unitOfWork.appointmentRepository.GetByIdAsync(id);
            if (entity == null)
                return response.MappingResponse();
            _unitOfWork.appointmentRepository.Delete(entity);
            bool isDeleted = await _unitOfWork.SaveAsync() > 0 ? true : false;
            return response.MappingResponse(isDeleted);
        }
    }
}
