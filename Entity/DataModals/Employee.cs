using Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.DataModals
{
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender? Gender { get; set; }
        public string? PersonalEmailAddress { get; set; }
        public string OfficialEmailAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; } 
        public string? Designation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public double? Experience { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermentAddress { get; set; }
        public string? ReportTo { get; set; }
        public string? ROEmailAddress { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Status? Status { get; set; } = Enum.Status.Inactive;

    }
}
