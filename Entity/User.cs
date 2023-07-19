using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public List<Departmant> Departmants { get; set; }
        public List<Branch> Branches { get; set; }       
        public Title Title { get; set; }
    }
}
