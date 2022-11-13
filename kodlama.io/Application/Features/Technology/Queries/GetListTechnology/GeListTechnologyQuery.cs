using Application.Features.Technology.Commands.Models;
using Application.Features.Technology.Dto;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Queries.GetListTechnology
{
    public class GeListTechnologyQuery:IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GeListTechnologyQueryHandler:IRequestHandler<GeListTechnologyQuery, TechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GeListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<TechnologyListModel> Handle(GeListTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technologies> technologies=await _technologyRepository.GetListAsync(include:

                                              m => m.Include(c => c.ProgramingLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize

                                              );
                TechnologyListModel mappedTechnology = _mapper.Map<TechnologyListModel>(technologies);
                return mappedTechnology;
            }
        }

    }
}
