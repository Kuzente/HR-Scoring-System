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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUserWithDepartmantsAndTitle(int id)
        {            
            return _userDal.GetUserWithDepartmantsAndTitle(id);
        }

        public List<User> GetUsersWithDepartmantsAndTitle()
        {
            return _userDal.GetUsersWithDepartmantsAndTitle();
        }

        public void TAdd(User entity)
        {
            _userDal.AddUser(entity);
        }

        public void TDelete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public void TUpdate(User entity)
        {
            _userDal.DeleteDepartmantsByUser(entity.ID); // ilk önce gelen User ın bridgedeki verileri siliniyor
            _userDal.UpdateUser(entity); // gelen user verileri update ediliyor.
        }

        public List<User> GetListByFilter(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetListByFilter(filter);
        }
    }
}
