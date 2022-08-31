using AutoMapper;
using BittiBitti.Application.Features.Users.Dtos.Request;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();
        }
    }
}
