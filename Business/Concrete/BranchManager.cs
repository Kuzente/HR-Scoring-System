using Business.Abstract;
using DataAccess.Abstract;
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
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public List<Branch> GetListByFilter(Expression<Func<Branch, bool>> filter)
        {
            return _branchDal.GetListByFilter(filter);
        }

        public void TAdd(Branch entity)
        {
            _branchDal.Add(entity);
        }

        public void TDelete(Branch entity)
        {
            _branchDal.Delete(entity);
        }

        public Branch TGetById(int id)
        {
            return _branchDal.GetById(id);
        }

        public List<Branch> TGetList()
        {
            return _branchDal.GetList();
        }

        public void TUpdate(Branch entity)
        {
            _branchDal.Update(entity);
        }
    }
}
