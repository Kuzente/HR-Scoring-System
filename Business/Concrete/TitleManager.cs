using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DTO;
using Entity;
using SamiProje.DataAccess.Abstract;
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
        private readonly IDepartmantDal _departmantDal;
        private readonly IMapper _mapper;
        public TitleManager(ITitleDal titleDal, IMapper mapper, IDepartmantDal departmantDal)
        {
            _titleDal = titleDal;
            _mapper = mapper;
            _departmantDal = departmantDal;
        }
        public void ChangeStatus(int id)
        {
            _titleDal.ChangeStatus(id);
        }
        public void TAdd(TitleDto entity)
        {
            var model = _mapper.Map<Title>(entity);
            _titleDal.Add(model);
        }
        public TitleDto TGetById(int id)
        {
            var model = _mapper.Map<TitleDto>(_titleDal.GetById(id));
            return model;
        }
        public List<TitleDto> TGetList()
        {
            var model = _mapper.Map<List<TitleDto>>(_titleDal.GetList());
            return model;
        }
        public void TUpdate(TitleDto entity)
        {
            var model = _mapper.Map<Title>(entity);
            model.Departmant = _departmantDal.GetById(model.Departmant.ID);
            _titleDal.UpdateTitle(model);
        }
        public List<TitleDto> GetTitlesWithDepartmant()
        {
            var model = _mapper.Map<List<TitleDto>>(_titleDal.GetTitlesWithDepartmant());
            return model;
        }
        public TitleDto GetTitleWithDepartmant(int id)
        {
            var model = _mapper.Map<TitleDto>(_titleDal.GetTitleWithDepartmant(id));
            return model;
        }
        public void TDelete(int id)
        {
            var model = _titleDal.GetById(id);
            _titleDal.Delete(model);
        }
    }
}
