using DTO.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto : Dto , IDto
    {
       // public List<DepartmantDto> Departmants{ get; set; } = new List<DepartmantDto>();
        public List<BranchDto> Branches{ get; set; } = new List<BranchDto>();
        public List<BranchDto> AllBranches { get; set; }
        public List<UserDto> Users { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
       // public List<int> DepartmantIds{ get; set; }
        public List<int> BranchIds{ get; set; }

    }
}
