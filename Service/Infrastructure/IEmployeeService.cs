using Entity.DataModals;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Service.Infrastructure
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<IActionResult> Update(EmployeeUpdateDTO dto);
    }
}
