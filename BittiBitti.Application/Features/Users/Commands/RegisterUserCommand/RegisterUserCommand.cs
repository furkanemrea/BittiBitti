using AutoMapper;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Application.Features.Users.Rules;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Domain.Entities;
using BittiBitti.Publisher.Signatures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Commands.RegisterUserCommand
{
    public partial class RegisterUserCommand : IRequest<EntityResponse<CreateUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, EntityResponse<CreateUserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public RegisterUserCommandHandler(IAbstractPublisher abstractPublisher,IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository=userRepository;
                _mapper=mapper;
                _userBusinessRules=userBusinessRules;
            }
            async Task<EntityResponse<CreateUserResponse>> IRequestHandler<RegisterUserCommand, EntityResponse<CreateUserResponse>>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
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
    
}
