using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task UserEmailCannotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result =  await _userRepository.GetListAsync(x=>x.Email == email);
            if (result.Items.Any()) throw new Exception("User Email is exist");
        }
    }
}
