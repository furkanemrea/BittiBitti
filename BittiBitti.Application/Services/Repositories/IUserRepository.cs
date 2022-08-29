using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Repositories;
using BittiBitti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
        Task<EntityResponse<IList<User>>> GetList();
    }
}
