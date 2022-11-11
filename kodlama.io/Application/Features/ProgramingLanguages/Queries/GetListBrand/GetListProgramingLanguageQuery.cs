using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetListBrand
{
    public class GetListProgramingLanguageQuery:IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest;

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;
            private readonly IMapper _mapper;
            private readonly IProgramingLanguageRepository _programingLanguageRepository;

            public GetListProgramingLanguageQueryHandler(ProgramingLanguageBusinessRules programingLanguageBusinessRules, IMapper mapper, IProgramingLanguageRepository programingLanguageRepository)
            {
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguage> programingLanguages = await _programingLanguageRepository.GetListAsync(index:request.PageRequest.Page ,size:request.PageRequest.PageSize);
                ProgramingLanguageListModel mappedProgramingLanguageModel = _mapper.Map<ProgramingLanguageListModel>(programingLanguages);
                return mappedProgramingLanguageModel;
            }
        }

    }
}
