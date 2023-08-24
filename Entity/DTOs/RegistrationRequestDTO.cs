using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class RegistrationRequestDTO
    {
        [Required]
        [RegularExpression("[A-Z]{1}[0-9]{4}", ErrorMessage = "Must be a valid Employee Code")]
        public string EmployeeCode { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string OfficialEmailAddress { get; set; } = null!;
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Must be a valid PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must be a valid Password")]
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
    }
}
