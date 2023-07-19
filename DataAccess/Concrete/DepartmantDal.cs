using SamiProje.DataAccess.GenericRepo;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamiProje.DataAccess.Abstract;

namespace SamiProje.DataAccess.Concrete
{
	public class DepartmantDal : GenericRepository<Departmant> , IDepartmantDal
	{
	}
}
