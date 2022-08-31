﻿using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Core.Models.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Dtos.Request
{
    public class CreateUserRequest : IRequest<EntityResponse<CreateUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}