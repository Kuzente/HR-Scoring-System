using AutoMapper;
using DTO;
using Entity;

namespace SamiProje.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Departmant,DepartmantDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<TitleQuestion, TitleQuestionDto>().ReverseMap();
            

        }
    }
}
