
using Entity.Base;
using Microsoft.EntityFrameworkCore;
using SamiProje.DataAccess.Abstract;
using SamiProje.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamiProje.DataAccess.GenericRepo
{
	public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
	{
		public void Add(T t)
		{
			using(Context context = new Context())
			{
				var entity = context.Entry(t);
				entity.State = EntityState.Added;
                context.SaveChanges();
            }
		}

		public void Delete(T t)
		{
			using (Context context = new Context())
			{
                var entity = context.Entry(t);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
		}
		public void Update(T t)
		{
			using (Context context = new Context())
			{
                var entity = context.Entry(t);
                entity.State = EntityState.Modified;
                context.SaveChanges();
			}
		}

		public T GetById(int id)
		{
			using (Context context = new Context())
			{
				return context.Set<T>().Find(id);
			}
		}

		public List<T> GetList()
		{
			using (Context context = new Context())
			{
				return context.Set<T>().ToList();
			}
		}

		public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
		{
			using (Context context = new Context())
			{
				return context.Set<T>().Where(filter).ToList();
			}
		}

        public void ChangeStatus(int id)
        {
			
            using (Context context = new Context())
            {
                var model = GetById(id);
                if (model.IsActive == true)
                {
                    model.IsActive = false;
                    
                }
                else
                {
                    model.IsActive = true;
                    
                }
				context.Entry(model).State = EntityState.Modified;
				context.SaveChanges();
            }
        }
    }
}
