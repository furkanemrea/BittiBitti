using BittiBitti.Application.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BittiBitti.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly IUserRepository UserRepository;

        public BaseController(IUserRepository userRepository)
        {
            UserRepository=userRepository;
        }


    }
}
