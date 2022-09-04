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
    internal class BrandRepository : EfRepositoryBase<Brand, PostgreDbContext>, IBrandRepository
    {
        public BrandRepository(PostgreDbContext context) : base(context)
        {
        }
        public async Task<EntityResponse<IPaginate<Brand>>> GetList()
        {
            EntityResponse<IPaginate<Brand>> responseModel = new();
            responseModel.Data =  await GetListAsync();
            return responseModel;
        }
    }
}
