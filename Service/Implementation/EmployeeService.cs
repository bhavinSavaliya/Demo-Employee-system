using AutoMapper;
using DataAccessLayer.Infrastructure;
using Entity.DataModals;
using Entity.DTOs;
using MagicVilla.Common.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;

namespace Service.Implementation
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public EmployeeService(IBaseRepo<Employee> baseRepo, IUnitOfWork unitOfWork, IMapper mapper) : base(baseRepo, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Update(EmployeeUpdateDTO dto)
        {
            var employee = await _unitOfWork.EmployeeRepo.GetAsync(x => x.OfficialEmailAddress == dto.OfficialEmailAddress);
            if (employee != null)
            {
                var emp = _mapper.Map<Employee>(dto);
                emp.DateOfBirth =dto.DateOfBirth.ToUniversalTime();
                emp.DateOfJoin = dto.DateOfJoin.ToUniversalTime();
                _unitOfWork.EmployeeRepo.Update(emp);
                return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "Updated Successfully");
            }
            return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "This user is not Registered");
        }
    }
}
