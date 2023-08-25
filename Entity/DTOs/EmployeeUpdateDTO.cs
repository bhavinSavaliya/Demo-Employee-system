using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public long EmployeeId { get; set; }
        [Required]
        public string EmployeeCode { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string PersonalEmailAddress { get; set; } = null!;
        [Required]
        public string OfficialEmailAddress { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Designation { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfJoin { get; set; }
        [Required]
        public double Experience { get; set; }
        public string CurrentAddress { get; set; } = null!;
        [Required]
        public string PermentAddress { get; set; } = null!;
        [Required]
        public string ReportTo { get; set; } = null!;
        [Required]
        public string ROEmailAddress { get; set; } = null!;
        [Required]
        public Role Role { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        public Status? Status { get; set; } = Enum.Status.Inactive;
    }
}
