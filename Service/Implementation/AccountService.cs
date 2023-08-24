using AutoMapper;
using Common.Helper;
using DataAccessLayer.Infrastructure;
using Entity.DataModals;
using Entity.DTOs;
using MagicVilla.Common.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;
using Utility.Service.Infrastructure;

namespace Service.Implementation
{
    public class AccountService : BaseService<Employee>, IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerationService _tokenGenerationService;
        private IMapper _mapper;
        private ISendMailService _sendMailService;
        private SecureHelper _secureHelper;
        public AccountService(IBaseRepo<Employee> baseRepo, 
                              IUnitOfWork unitOfWork, 
                              IMapper mapper, 
                              ITokenGenerationService tokenGenerationService,
                              ISendMailService sendMailService,
                              SecureHelper secureHelper) : base(baseRepo, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenGenerationService = tokenGenerationService;
            _sendMailService = sendMailService;
            _secureHelper = secureHelper;
        }

        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var employee = await _unitOfWork.EmployeeRepo.GetAsync(x => x.OfficialEmailAddress == dto.OfficialEmailAddress);
            if (employee != null)
            {
                if (employee.Password == dto.Password && employee.OfficialEmailAddress == dto.OfficialEmailAddress)
                {
                    var result = _mapper.Map<LoginResponseDTO>(employee);
                    var tokenDto = _mapper.Map<TokenDTO>(employee);
                    result.Token = _tokenGenerationService.GenerateToken(tokenDto);
                    return SuccessResponseHelper<LoginResponseDTO>.GetSuccessResponse(StatusCodes.Status200OK, "Logged In", result);
                }
                return SuccessResponseHelper<LoginResponseDTO>.GetSuccessResponse(StatusCodes.Status500InternalServerError, "Invalid UserName and Password");
            }
            return SuccessResponseHelper<LoginResponseDTO>.GetSuccessResponse(StatusCodes.Status404NotFound, "User not Found");
        }

        public async Task<IActionResult> Register(RegistrationRequestDTO dto)
        {
            if (!_unitOfWork.EmployeeRepo.IsEnityExist(x => x.OfficialEmailAddress == dto.OfficialEmailAddress) &&
                !_unitOfWork.EmployeeRepo.IsEnityExist(x => x.EmployeeCode == dto.EmployeeCode))
            {
                var employee = _mapper.Map<Employee>(dto);
                employee.CreatedOn = DateTime.Now.ToUniversalTime();
                _unitOfWork.EmployeeRepo.Add(employee);
                return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "Success");
            }
            return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "Employee Already Exist");
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            var employee = await _unitOfWork.EmployeeRepo.GetAsync(x => x.OfficialEmailAddress == _secureHelper.Decryption(dto.OfficialEmailAddress));
            if (employee != null)
            {
                employee.Password = dto.NewPassword;
                _unitOfWork.EmployeeRepo.Update(employee);
                return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "Password changed Successfully!, Please login with new credential.");
            }
            return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status404NotFound, "User not Found");
        }
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
        {
            var user = await _unitOfWork.EmployeeRepo.GetAsync(x => x.OfficialEmailAddress == dto.OfficialEmailAddress);
            if (user != null)
            {
                string email = _secureHelper.Encryption(dto.OfficialEmailAddress);
                _sendMailService.SendMail(dto.OfficialEmailAddress, "Reset Password", email);
                return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status200OK, "Reset password link has been sended on your registered mailId");
            }
            return SuccessResponseHelper<string>.GetSuccessResponse(StatusCodes.Status404NotFound, "User not Found! Please enter registered mailId.");
        }
    }
}
