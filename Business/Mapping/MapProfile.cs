using AutoMapper;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Departmant, DepartmantDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<TitleQuestion, TitleQuestionDto>().ReverseMap();


        }
    }
}
