using DataAccess.Abstract;
using Entity;
using SamiProje.DataAccess.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BranchDal : GenericRepository<Branch> , IBranchDal
    {
    }
}
