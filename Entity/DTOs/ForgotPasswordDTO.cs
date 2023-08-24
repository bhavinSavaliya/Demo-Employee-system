using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class ForgotPasswordDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string OfficialEmailAddress { get; set; } = null!;
    }
}
