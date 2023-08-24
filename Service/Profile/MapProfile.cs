
using Entity.DataModals;
using Entity.DTOs;

namespace Service.Service.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
           CreateMap<Employee, RegistrationRequestDTO>().ReverseMap();
            CreateMap<LoginRequestDTO, Employee>().ReverseMap();
            CreateMap<LoginResponseDTO, Employee>().ReverseMap();
            CreateMap<TokenDTO, Employee>().ReverseMap();
            //CreateMap<ResetPasswordDTO, User>().ReverseMap();
            CreateMap<EmployeeUpdateDTO, Employee>().ForMember(dest => dest.DateOfBirth, opt => opt.Ignore())
                .ForMember(dest => dest.DateOfJoin, opt => opt.Ignore()).ReverseMap();
        }
    }
}
