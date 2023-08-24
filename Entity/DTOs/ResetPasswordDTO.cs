using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class ResetPasswordDTO
    {
        [Required]
        public string OfficialEmailAddress { get; set; } = null!;
        [Required]
        [RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must be a valid Password")]
        public string NewPassword { get; set; } = null!;
        [Required]
        [RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must be a valid Password")]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
