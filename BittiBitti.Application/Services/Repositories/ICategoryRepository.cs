using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Core.Persistence.Repositories;
using BittiBitti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Services.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>, IRepository<Category>
    {
        Task<EntityResponse<IPaginate<Category>>> GetList();
    }
}
