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

namespace Application.Features.ProgramingLanguages.Commands.DeletedLanguage
{
    public class DeleteProgramingLanguageCommand:IRequest<DeletedProgramingLanguageDto>
    {
        public int Id { get; set; }


        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgramingLanguageRepository _programingLanguagerepository;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteProgramingLanguageCommandHandler(IMapper mapper, IProgramingLanguageRepository programingLanguagerepository, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _mapper = mapper;
                _programingLanguagerepository = programingLanguagerepository;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedLanguage = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage DeleteLanguage = await _programingLanguagerepository.DeleteAsync(mappedLanguage);
                DeletedProgramingLanguageDto deleteedProgramingLanguagesDto = _mapper.Map<DeletedProgramingLanguageDto>(DeleteLanguage);
                return deleteedProgramingLanguagesDto;
            }
        }
    }
}
