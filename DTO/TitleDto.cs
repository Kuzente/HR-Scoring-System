using DTO.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TitleDto : Dto , IDto
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Departmant Departmant { get; set; }
        public List<Title> Titles { get; set; }
        
    }
}
