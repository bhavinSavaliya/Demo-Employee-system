using DataAccessLayer.Context;
using DataAccessLayer.Infrastructure;
using Entity.DataModals;

namespace DataAccessLayer.Implementation
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
