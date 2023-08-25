using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Service.Infrastructure
{
    public interface ISalaryCalculationService
    {
        ActionResult<decimal> GetSalary(SalaryCalculatorDTO model);
    }
}
