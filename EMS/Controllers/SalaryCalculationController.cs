using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCalculationController : ControllerBase
    {
        private readonly ISalaryCalculationService _service;

        public SalaryCalculationController()
        {
        }

        public SalaryCalculationController(ISalaryCalculationService service)
        {
            _service = service;
        }
        [HttpPost]
        public decimal CalculateGrossSalary(SalaryCalculatorDTO model)
        {
            //return _service.GetSalary(model);
            // Calculate gross salary (assuming a fixed allowance and deductions)
            decimal allowance = 0.2m * model.BasicSalary;
            decimal deductions = 0.1m * model.BasicSalary;
            decimal grossSalary = model.BasicSalary + allowance - deductions;

            return grossSalary;
        }

        [HttpPost]
        public decimal CalculateGrossSalaryCorrect(decimal basicSalary)
        {
            return basicSalary + (0.2M * basicSalary); // 20% bonus
            
        }
    }
}
