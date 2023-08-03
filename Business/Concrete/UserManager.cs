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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public void ChangeStatus(int id)
        {
            _userDal.ChangeStatus(id);
        }
        public List<UserDto> GetUsersWithDepartmantsAndTitle()
        {
            var model = _userDal.GetUsersWithDepartmantsAndTitle();
            return _mapper.Map<List<UserDto>>(model);
        }
        public UserDto GetUserWithDepartmantsAndTitle(int id)
        {
            var model = _userDal.GetUserWithDepartmantsAndTitle(id);
            return _mapper.Map<UserDto>(model);
        }
        public void TAdd(UserDto entity)
        {
            var model = _mapper.Map<User>(entity);
            _userDal.AddUser(model);
        }
        public void TDelete(int id)
        {
            var model = _userDal.GetById(id);
            _userDal.Delete(model);
        }
        public UserDto TGetById(int id)
        {
            var model = _userDal.GetById(id);
            return _mapper.Map<UserDto>(model);
        }
        public List<UserDto> TGetList()
        {
            var model = _userDal.GetList();
            return _mapper.Map<List<UserDto>>(model);
        }
        public void TUpdate(UserDto entity)
        {
            _userDal.DeleteDepartmantsByUser(entity.ID);
            var model = _mapper.Map<User>(entity);
            _userDal.UpdateUser(model);
        }
    }
}
