﻿using BittiBitti.Application.Features.Users.Rules;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Dynamic;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Core.Persistence.Repositories;
using BittiBitti.Domain.Entities;
using BittiBitti.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BittiBitti.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, PostgreDbContext>, IUserRepository
    {
        public UserRepository(PostgreDbContext context) : base(context)
        {
        }


        public async Task<EntityResponse<IPaginate<User>>> GetList()
        {
            EntityResponse<IPaginate<User>> responseModel = new();
            responseModel.Data =  await GetListAsync();
            return responseModel;
        }
    }
}
