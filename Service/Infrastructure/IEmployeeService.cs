using Entity.DataModals;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Service.Infrastructure
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<IActionResult> Delete(long employeeId);
        Task<IActionResult> Update(EmployeeUpdateDTO dto);
    }
}
