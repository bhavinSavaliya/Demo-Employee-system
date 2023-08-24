using Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDTO dto)
        {
            return await _service.Register(dto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginRequestDTO dto)
        {
            return await _service.Login(dto);
        }
        
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
        {
            return await _service.ForgotPassword(dto);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            return await _service.ResetPassword(dto);
        }
    }
}
