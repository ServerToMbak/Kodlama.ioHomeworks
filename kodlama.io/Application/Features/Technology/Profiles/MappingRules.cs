using Application.Features.ProgramingLanguages.Commands.CreateLanguages;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.Models;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.CreateTechnology;
using Application.Features.Technology.Dto;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Profiles
{
    public class MappingRules:Profile
    {
        public MappingRules()
        {
            CreateMap<Technologies, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technologies, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technologies, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technologies, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technologies, UpdateTechnologyDto>().ReverseMap();
            CreateMap<Technologies, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technologies,TechnologyListDto>().ForMember(c=>c.ProgramingLanguageName,opt=>opt.MapFrom(c=>c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technologies>, TechnologyListModel>().ReverseMap();
            CreateMap<Technologies, TechnologyListDto>().ReverseMap();
        }
    }
}
