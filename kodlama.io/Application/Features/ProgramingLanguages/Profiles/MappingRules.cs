using Application.Features.ProgramingLanguages.Commands.CreateLanguages;
using Application.Features.ProgramingLanguages.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingRules:Profile
    {
        public MappingRules()
        {
            CreateMap<ProgramingLanguage, CreatedProgramingLanguagesDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();

        }
    }
}
