using AutoMapper;
using Business.Abstract;
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
    public class DepartmantManager : IDepartmantService
    {
        private readonly IDepartmantDal _departmantDal;
        private readonly IMapper _mapper;

        public DepartmantManager(IDepartmantDal departmantdal, IMapper mapper)
        {
            _departmantDal = departmantdal;
            _mapper = mapper;
        }
        public void ChangeStatus(int id)
        {
            _departmantDal.ChangeStatus(id);
        }
        public void TAdd(DepartmantDto entity)
        {
            var model = _mapper.Map<Departmant>(entity);
            _departmantDal.Add(model);
        }
        public void TDelete(int id)
        {
            var model = _departmantDal.GetById(id);
            _departmantDal.Delete(model);
        }
        public DepartmantDto TGetById(int id)
        {
            var model = _mapper.Map<DepartmantDto>(_departmantDal.GetById(id));
            return model;
        }
        public List<DepartmantDto> TGetList()
        {
            var model = _mapper.Map<List<DepartmantDto>>(_departmantDal.GetList());
            return model;
        }
        public void TUpdate(DepartmantDto entity)
        {
            var model = _mapper.Map<Departmant>(entity);
            _departmantDal.Update(model);
        }
    }
}
