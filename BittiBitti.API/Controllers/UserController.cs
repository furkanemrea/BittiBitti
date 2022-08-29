using BittiBitti.Application.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BittiBitti.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        [HttpGet]
        [Route("get-list")]
        public IActionResult GetList()
        {
            return Ok(_userRepository.GetList());
        }
    }
}
