using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using SamiProje.DataAccess.Concrete;
using SamiProje.DataAccess.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TitleQuestionDal : GenericRepository<TitleQuestion>, ITitleQuestionDal
    {
        
    }
}
