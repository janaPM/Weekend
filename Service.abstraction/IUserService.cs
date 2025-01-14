﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.abstraction
{
    public interface IUserService
    {
        Task<UserModel> GetUser(string id);
        Task<DatabaseResponse> EditUser(UserModel userModel);

    }
}
