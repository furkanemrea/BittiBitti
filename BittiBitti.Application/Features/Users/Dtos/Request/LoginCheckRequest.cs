﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Dtos.Request
{
    public class LoginCheckRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
