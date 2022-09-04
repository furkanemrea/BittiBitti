using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Core.Persistence.Repositories;
using BittiBitti.Domain.Entities;
using BittiBitti.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Persistence.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, PostgreDbContext>, ICategoryRepository
    {
        public CategoryRepository(PostgreDbContext context) : base(context)
        {
        }
        public async Task<EntityResponse<IPaginate<Category>>> GetList()
        {
            EntityResponse<IPaginate<Category>> responseModel = new();
            responseModel.Data =  await GetListAsync();
            return responseModel;
        }
    }
}
