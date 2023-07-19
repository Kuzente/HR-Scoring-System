using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public List<Title> GetListByFilter(Expression<Func<Title, bool>> filter)
        {
            return _titleDal.GetListByFilter(filter);
        }

        public void TAdd(Title entity)
        {
            _titleDal.Add(entity);
        }

        public void TDelete(Title entity)
        {
            _titleDal.Delete(entity);
        }

        public Title TGetById(int id)
        {
            return _titleDal.GetTitleWithDepartmant(id);
        }

        public List<Title> TGetList()
        {
            return _titleDal.GetTitlesWithDepartmant();
        }

        public void TUpdate(Title entity)
        {
            _titleDal.UpdateTitle(entity); // burada departmandan gelen değeri EntityState yakalayamadığı için .update metodu kullanılan fonksiyona yönd
        }
    }
}
