using DTO.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepartmantDto : Dto,IDto
    {
        public List<DepartmantDto> Departmants { get; set; } 
        public string Name { get; set; }
        public int Weight { get; set; }
       
    }
}
