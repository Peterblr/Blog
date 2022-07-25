﻿using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Interfaces
{
    public interface IUserService
    {
        ApplicationUser GetUser(string id);

        Task<ApplicationUser> UpdateUser(ApplicationUser applicationUser);
    }
}
