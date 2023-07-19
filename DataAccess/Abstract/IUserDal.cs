using Entity;
using SamiProje.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        List<User> GetUsersWithDepartmantsAndTitle();
        User GetUserWithDepartmantsAndTitle(int id);
        void DeleteDepartmantsByUser(int id);
        void AddUser(User model);
        void UpdateUser(User model);
    }
}
