using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
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
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
           

            public RegisterCommandHandler(IAuthService authService, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailCanNotBeDublicatedWhenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passwordHash, out passwordSalt);
                User user = new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Status = true,
                };
                User CreatedUser =await _userRepository.AddAsync(user);

                
                AccessToken createdAccessToken = await _authService.CreateAccessToken(CreatedUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(CreatedUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };

                return registeredDto;
            }
        }
    }
}
