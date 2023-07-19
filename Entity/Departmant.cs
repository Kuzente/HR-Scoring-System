using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Departmant : BaseEntity
	{
		public string Name { get; set; }
		public int Weight { get; set; }
        public List<User> Users { get; set; }
        public List<Title> Titles { get; set; }
    }
}
