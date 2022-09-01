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

namespace BittiBitti.Application.Features.Users.Queries.LoginCheckQuery
{
    public partial class LoginCheckQuery : IRequest<EntityResponse<LoginCheckResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginCheckQueryHandler : IRequestHandler<LoginCheckQuery, EntityResponse<LoginCheckResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            public LoginCheckQueryHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
            {
                _userRepository=userRepository;
                _userBusinessRules=userBusinessRules;
            }

            public async Task<EntityResponse<LoginCheckResponse>> Handle(LoginCheckQuery request, CancellationToken cancellationToken)
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
    
}
