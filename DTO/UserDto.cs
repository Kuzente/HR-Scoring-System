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
        public List<Departmant> Departmants{ get; set; } = new List<Departmant>();
        public List<Branch> Branches{ get; set; } = new List<Branch>();
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public List<User> Users{ get; set; }
        public List<int> DepartmantIds{ get; set; }
        public List<int> BranchIds{ get; set; }

    }
}
