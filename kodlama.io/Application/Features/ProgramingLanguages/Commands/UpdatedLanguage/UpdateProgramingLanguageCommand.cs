using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdatedLanguage
{
    public class UpdateProgramingLanguageCommand:IRequest<EditedProgramingLanguageDto>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, EditedProgramingLanguageDto>
        {
            IMapper _mapper;
            IProgramingLanguageRepository _programingLanguageRepository;
            ProgramingLanguageBusinessRules _programingLanaguageBusinessRules;

            public UpdateProgramingLanguageCommandHandler(IMapper mapper, IProgramingLanguageRepository programingLanguageRepository, ProgramingLanguageBusinessRules programingLnaguageBusinessRules)
            {
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
                _programingLanaguageBusinessRules = programingLnaguageBusinessRules;
            }

            public async Task<EditedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedLanguae= _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdLanguage =await _programingLanguageRepository.UpdateAsync(mappedLanguae);
                EditedProgramingLanguageDto editedProgramingLanguageDto= _mapper.Map<EditedProgramingLanguageDto>(createdLanguage);
                return editedProgramingLanguageDto;
            }
        }
    }
}
