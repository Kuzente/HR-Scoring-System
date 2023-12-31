﻿using DTO;
using Entity;
using SamiProje.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<UserDto>
    {
        List<UserDto> GetUsersWithDepartmantsAndTitle();
        UserDto GetUserWithDepartmantsAndTitle(int id);
    }
}
