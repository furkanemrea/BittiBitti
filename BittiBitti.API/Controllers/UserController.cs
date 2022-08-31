﻿using BittiBitti.Application.Features.Users.Dtos.Request;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Domain.Entities;
using BittiBitti.Persistence.Contexts;
using BittiBitti.Persistence.Repositories;
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
        public UserController(IUserRepository userRepository) : base(userRepository)
        {

        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {
            EntityResponse<IPaginate<User>> responseModel = await UserRepository.GetList();
            return Ok(responseModel);
        }
        [HttpPost]
        [Route("login-check")]
        public async Task<IActionResult> LoginCheck(LoginCheckRequest loginCheckRequest)
        {
            EntityResponse<User> responseModel = UserRepository.LoginCheck(loginCheckRequest);
            return Ok(responseModel);
        }
    }
}
