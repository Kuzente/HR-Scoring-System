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
    public class UserDal : GenericRepository<User>, IUserDal
    {
        public void AddUser(User model)
        {
            using (Context context = new Context())
            {
                var entity = context.Entry(model);
                model.TitleID = 1;
                //context.AttachRange(model.Departmants);
                context.AttachRange(model.Branches);             
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void UpdateUser(User model)
        {
            using (Context context = new Context())
            {
                
                var entity = context.Entry(model);               
                //context.UpdateRange(model.Departmants);
                context.UpdateRange(model.Branches);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteDepartmantsByUser(int id)
        {
            using (Context context = new Context())
            {
               var oldUser =  context.Users.Where(p => p.ID == id)
                                                                  //.Include(p => p.Departmants)
                                                                  .Include(b => b.Branches)
                                                                  .FirstOrDefault();
                //oldUser?.Departmants.Clear();
                oldUser?.Branches.Clear();
                context.SaveChanges();
            }
        }
        public User GetUserWithDepartmantsAndTitle(int id)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(p => p.ID == id)
                    //.Include(d => d.Departmants)
                    .Include(b => b.Branches)
                    .Include(t => t.Title)
                    .ThenInclude(d => d.Departmant)
                    .FirstOrDefault();
            }
        }

        public List<User> GetUsersWithDepartmantsAndTitle()
        {
            using (Context context = new Context())
            {
                return context.Users
                    //.Include(d=> d.Departmants)
                    .Include(b => b.Branches)
                    .Include(b=> b.Title)
                    .ThenInclude(d=> d.Departmant)
                    .ToList();
            }
        }

    }
}
