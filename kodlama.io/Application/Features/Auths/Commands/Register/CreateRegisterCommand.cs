using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class CreateRegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAdress { get; set; }

        public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand, RegisteredDto>
        {
            private readonly IAuthenticationService _authService;
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationRepository;

            public CreateRegisterCommandHandler(IAuthenticationService authService, IUserRepository userRepository, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationRepository)
            {
                _authService = authService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _userOperationRepository = userOperationRepository;
            }

            public async Task<RegisteredDto> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passwordHash, out passwordSalt);
                User user = new()
                {
                    FirstName = request.UserForRegisterDto.
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Status = true,
                };
                User AddedUser =await _userRepository.AddAsync(user);
                UserOperationClaim userOperationClaim = new() { OperationClaimId = 1,UserId=AddedUser.Id };
                AccessToken accessToken = await _authService.CreateAccessToken(user);


            }
        }
    }
}
