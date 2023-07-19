using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Departmant Departmant { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
