using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TitleQuestion : BaseEntity
    {
        public string Content { get; set; }
        public int Weight { get; set; }
        public Title Title { get; set; }
        public int TitleID { get; set; }
    }
}
