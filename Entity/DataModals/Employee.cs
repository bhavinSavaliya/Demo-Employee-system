using System.ComponentModel.DataAnnotations;

namespace Entity.DataModals
{
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Designation { get; set; } = null!;
    }
}
