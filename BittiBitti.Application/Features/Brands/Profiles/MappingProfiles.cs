using AutoMapper;
using BittiBitti.Application.Features.Brands.Dtos.Response;
using BittiBitti.Application.Features.Categories.Dtos.Response;
using BittiBitti.Application.Features.Users.Commands.RegisterUserCommand;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, GetBrandsQueryResponse>().ReverseMap();
        }
    }
}
