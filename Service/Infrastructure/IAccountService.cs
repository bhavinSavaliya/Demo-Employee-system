using Entity.DataModals;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Service.Infrastructure
{
    public interface IAccountService : IBaseService<Employee>
    {
        Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto);
        Task<IActionResult> Login(LoginRequestDTO dto);
        Task<IActionResult> Register(RegistrationRequestDTO dto);
        Task<IActionResult> ResetPassword(ResetPasswordDTO dto);
    }
}
