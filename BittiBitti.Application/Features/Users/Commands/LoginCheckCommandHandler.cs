using BittiBitti.Application.Features.Users.Dtos.Request;
using BittiBitti.Application.Features.Users.Dtos.Response;
using BittiBitti.Application.Features.Users.Rules;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.CustomHandlers.Exceptions;
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
    public class LoginCheckCommandHandler : IRequestHandler<LoginCheckRequest, EntityResponse<LoginCheckResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        public LoginCheckCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
        {
            _userRepository=userRepository;
            _userBusinessRules=userBusinessRules;
        }

        public async Task<EntityResponse<LoginCheckResponse>> Handle(LoginCheckRequest request, CancellationToken cancellationToken)
        {
            EntityResponse<LoginCheckResponse> responseModel = new();
            LoginCheckResponse loginCheckResponse = new LoginCheckResponse();
            User user = await _userRepository.GetAsync(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
            {
                responseModel.Code = ResponseCodes.Error;
            }
            else
            {
                loginCheckResponse.Name = user.Name;
                loginCheckResponse.Surname = user.Surname;
                loginCheckResponse.SetFullname();

                responseModel.Code = ResponseCodes.Success;
                responseModel.Data = loginCheckResponse;
            }
            return responseModel;
        }
    }
}
