using AutoMapper;
using BittiBitti.Application.Features.Users.Dtos.Request;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Application.Features.Users.Rules;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<CreateUserRequest, EntityResponse<CreateUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository=userRepository;
            _mapper=mapper;
            _userBusinessRules=userBusinessRules;
        }

        async Task<EntityResponse<CreateUserResponse>> IRequestHandler<CreateUserRequest, EntityResponse<CreateUserResponse>>.Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            EntityResponse<CreateUserResponse> responseModel = new();
            User mappedUser = _mapper.Map<User>(request);
            await _userBusinessRules.UserEmailCannotBeDuplicatedWhenInserted(mappedUser.Email);
            await _userRepository.AddAsync(mappedUser);
            CreateUserResponse createUserResponse = _mapper.Map<CreateUserResponse>(mappedUser);
            responseModel.Success(createUserResponse);
            return responseModel;
        }
    }
}
