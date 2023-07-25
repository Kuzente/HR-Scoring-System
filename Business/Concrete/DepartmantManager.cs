using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamiProje.Business.Abstract;
using SamiProje.DataAccess.Abstract;
using DTO;
using System.Linq.Expressions;

namespace SamiProje.Business.Concrete
{
	public class DepartmantManager : IDepartmantService
	{
		private readonly IDepartmantDal _departmantDal;
		

		public DepartmantManager(IDepartmantDal departmantDal)
		{
			_departmantDal = departmantDal;
		}

        public void ChangeStatus(int id)
        {
            _departmantDal.ChangeStatus(id);
        }

        public List<Departmant> GetListByFilter(Expression<Func<Departmant, bool>> filter)
        {
            return _departmantDal.GetListByFilter(filter);
        }

        public void TAdd(Departmant entity)
		{
           _departmantDal.Add(entity);
            
		}

		public void TDelete(Departmant entity)
		{
			_departmantDal.Delete(entity);
		}

		public Departmant TGetById(int id)
		{
			return _departmantDal.GetById(id);
		}

		public List<Departmant> TGetList()
		{
			return _departmantDal.GetList();
		}

		public void TUpdate(Departmant entity)
		{
			_departmantDal.Update(entity);
		}
	}
}
