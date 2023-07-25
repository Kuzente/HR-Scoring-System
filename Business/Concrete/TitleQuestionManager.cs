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
    public class TitleQuestionManager : ITitleQuestionService
    {
        private readonly ITitleQuestionDal _titleQuestionDal;

        public TitleQuestionManager(ITitleQuestionDal titleQuestionDal)
        {
            _titleQuestionDal = titleQuestionDal;
        }

        public void ChangeStatus(int id)
        {
            _titleQuestionDal.ChangeStatus(id);
        }

        public List<TitleQuestion> GetListByFilter(Expression<Func<TitleQuestion, bool>> filter)
        {
            return _titleQuestionDal.GetListByFilter(filter);
        }

        public void TAdd(TitleQuestion entity)
        {
            _titleQuestionDal.Add(entity);
        }

        public void TDelete(TitleQuestion entity)
        {
            _titleQuestionDal.Delete(entity);
        }

        public TitleQuestion TGetById(int id)
        {
            return _titleQuestionDal.GetById(id);
        }

        public List<TitleQuestion> TGetList()
        {
            return _titleQuestionDal.GetList();
        }

        public void TUpdate(TitleQuestion entity)
        {
            _titleQuestionDal.Update(entity);
        }
    }
}
