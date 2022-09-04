using BittiBitti.Application.Features.Users.Commands.RegisterUserCommand;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Application.Features.Users.Queries.LoginCheckQuery;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Domain.Entities;
using BittiBitti.Persistence.Contexts;
using BittiBitti.Persistence.Repositories;
using BittiBitti.Publisher.Signatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BittiBitti.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : BaseController
    {

        private readonly IAbstractPublisher _abstractPublisher;

        public UserController(IAbstractPublisher abstractPublisher)
        {


            _abstractPublisher=abstractPublisher;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
  
            return Ok();
        }

        [HttpGet]
        [Route("login-check")]
        public async Task<IActionResult> LoginCheck(string email, string password)
        {
            LoginCheckQuery loginCheckQuery = new LoginCheckQuery()
            {
                Email=email,
                Password=password
            };
            EntityResponse<LoginCheckResponse> loginCheckResponse = await base.Mediator.Send(loginCheckQuery);
            return Ok(loginCheckResponse);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
        {
            EntityResponse<CreateUserResponse> createUserResponse = await base.Mediator.Send(registerUserCommand);
            if (createUserResponse.Code == ResponseCodes.Success)
            {
                RegisterUserNotifyModel registerUserNotifyModel = new(type: "email", routingKey: "test")
                {
                    MailBody = $"Welcome {registerUserCommand.Name}",
                    MailTo=registerUserCommand.Email,
                    Subject=$"Welcome To BittiBitti"
                };
                _abstractPublisher.BasicPublish(registerUserNotifyModel);
            }
            return Ok(createUserResponse);
        }

    }
}
