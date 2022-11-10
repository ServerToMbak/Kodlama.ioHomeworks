using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.CreateLanguages
{
    public class CreateProgramingLanguageCommand :IRequest<CreatedProgramingLanguagesDto>
    {
        public string Name { get; set; }

        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguagesDto>
        {

            private readonly IMapper _mapper;
            private readonly IProgramingLanguageRepository _programingLanguageRpository;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
            public CreateProgramingLanguageCommandHandler(IMapper mapper, IProgramingLanguageRepository programingLanguageRpository, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _mapper = mapper;
                _programingLanguageRpository = programingLanguageRpository;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<CreatedProgramingLanguagesDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
              await _programingLanguageBusinessRules.LanguageConNotBeDuplicatedWhenInserted(request.Name);
                
                ProgramingLanguage mappedLanguage=_mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage CreateLanguage =await _programingLanguageRpository.AddAsync(mappedLanguage);
                CreatedProgramingLanguagesDto createdProgramingLanguagesDto = _mapper.Map<CreatedProgramingLanguagesDto>(CreateLanguage);
                return createdProgramingLanguagesDto;
            }
        }
    }
}
