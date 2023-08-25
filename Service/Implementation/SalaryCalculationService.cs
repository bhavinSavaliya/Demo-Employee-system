using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Infrastructure;

namespace Service.Implementation
{
    public class SalaryCalculationService : ISalaryCalculationService
    {
        public ActionResult<decimal> GetSalary(SalaryCalculatorDTO model)
        {
            decimal allowance = 0.2m * model.BasicSalary;
            decimal deductions = 0.1m * model.BasicSalary;
            decimal grossSalary = model.BasicSalary + allowance - deductions;

            return grossSalary;
        }
    }
}
