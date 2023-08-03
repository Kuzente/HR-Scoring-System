using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;
        private readonly IMapper _mapper;

        public BranchManager(IBranchDal branchDal, IMapper mapper)
        {
            _branchDal = branchDal;
            _mapper = mapper;
        }
        public void ChangeStatus(int id)
        {
            _branchDal.ChangeStatus(id);
        }
        public void TAdd(BranchDto entity)
        {
            var model = _mapper.Map<Branch>(entity);
            _branchDal.Add(model);
        }

        public void TDelete(int id)
        {
            var model = _branchDal.GetById(id);
            _branchDal.Delete(model);
        }
        public BranchDto TGetById(int id)
        {
            var model = _mapper.Map<BranchDto>(_branchDal.GetById(id));
            return model;
        }
        public List<BranchDto> TGetList()
        {
            var model = _mapper.Map<List<BranchDto>>(_branchDal.GetList());
            return model;
        }
        public void TUpdate(BranchDto entity)
        {
            var model = _mapper.Map<Branch>(entity);
            _branchDal.Update(model);
        }
    }
}
