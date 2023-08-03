using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DTO;
using Entity;
using SamiProje.DataAccess.Abstract;
using SamiProje.DataAccess.Concrete;
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
        private readonly IMapper _mapper;

        public TitleQuestionManager(ITitleQuestionDal titleQuestionDal, IMapper mapper)
        {
            _titleQuestionDal = titleQuestionDal;
            _mapper = mapper;
        }
        public void ChangeStatus(int id)
        {
            _titleQuestionDal.ChangeStatus(id);
        }
        public List<TitleQuestionDto> GetQuestionsByTitleID(int id)
        {
            var titleQuestions = _titleQuestionDal.GetListByFilter(p => p.TitleID == id);
            return _mapper.Map<List<TitleQuestionDto>>(titleQuestions);
        }
        public void TAdd(TitleQuestionDto entity)
        {
            var model = _mapper.Map<TitleQuestion>(entity);
            _titleQuestionDal.Add(model);
        }
        public void TDelete(int id)
        {
            var model = _titleQuestionDal.GetById(id);
            _titleQuestionDal.Delete(model);
        }
        public TitleQuestionDto TGetById(int id)
        {
            var model = _mapper.Map<TitleQuestionDto>(_titleQuestionDal.GetById(id));
            return model;
        }
        public List<TitleQuestionDto> TGetList()
        {
            var model = _mapper.Map<List<TitleQuestionDto>>(_titleQuestionDal.GetList());
            return model;
        }
        public void TUpdate(TitleQuestionDto entity)
        {
            var model = _mapper.Map<TitleQuestion>(entity);
            _titleQuestionDal.Update(model);
        }
    }
}
