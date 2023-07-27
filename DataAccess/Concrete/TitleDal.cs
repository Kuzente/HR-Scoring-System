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
    public class TitleDal : GenericRepository<Title>, ITitleDal
    {
        public List<Title> GetTitlesWithDepartmant()
        {
            using (Context context = new Context())
            {
                return context.Titles                   
                    .Include(p => p.Departmant)                   
                    .ToList();
            }
        }

        public Title GetTitleWithDepartmant(int id)
        {
            using (Context context = new Context())
            {
                return context.Titles
                    .Where(p=> p.ID == id)
                    .Include(p => p.Departmant)
                    .FirstOrDefault();
            }
        }

        public List<Title> GetTitleWithQuestions()
        {
            throw new NotImplementedException();
        }

        public void UpdateTitle(Title title)
        {
            using (Context context = new Context())
            {
                context.Set<Title>().Update(title);
                context.SaveChanges();
            }
        }
        
    }
}
