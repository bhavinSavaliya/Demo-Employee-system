using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string OfficialEmailAddress { get; set; } = null!;

        [Required]
        [RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must be a valid Password")]
        public string Password { get; set; } = null!;

        [Required]
        [RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must be a valid Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
