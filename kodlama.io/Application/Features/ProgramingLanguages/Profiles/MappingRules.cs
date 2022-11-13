using Application.Features.ProgramingLanguages.Commands.CreateLanguages;
using Application.Features.ProgramingLanguages.Commands.DeletedLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdatedLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
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
            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageGetByIdDto>().ReverseMap();
            CreateMap<ProgramingLanguage, DeletedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();
            CreateMap<ProgramingLanguage, EditedProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();
        }
    }
}
