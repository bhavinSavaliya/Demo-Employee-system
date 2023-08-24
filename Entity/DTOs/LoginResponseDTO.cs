using Entity.Enum;

namespace Entity.DTOs
{
    public class LoginResponseDTO
    {
        public string OfficialEmailAddress { get; set; }
        public string EmployeeCode { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
