using Core.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class CreateLoginCommand
    {
        public UserForLoginDto s { get; set; }
    }
}
