using Entity.DataModals;
using Entity.DTOs;
using MagicVilla.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _service.GetAllAsync();
            return SuccessResponseHelper<Employee>.GetSuccessResponse(StatusCodes.Status200OK, "Success", result.ToList());
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EmployeeUpdateDTO dto)
        {
            return await _service.Update(dto);
            
        }
    }
}
