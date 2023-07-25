using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamiProje.DataAccess.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		void Add(T t);
		void Delete(T t);
		void Update(T t);
		void ChangeStatus(int id);
		List<T> GetList();
		T GetById(int id);
		List<T> GetListByFilter(Expression<Func<T, bool>> filter);
	}
}
