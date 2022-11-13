using Application.Features.Technology.Dto;
using Application.Features.Technology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            IMapper _mapper;
            ITechnologyRepository _technologyRepository;
            TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technologies CreatedTechnology = _mapper.Map<Technologies>(request);
                Technologies MappedTechnology = await _technologyRepository.DeleteAsync(CreatedTechnology);
                DeletedTechnologyDto deletedTechnologyDto=_mapper.Map<DeletedTechnologyDto>(MappedTechnology);
                return deletedTechnologyDto;
            }
        }
    }
}
