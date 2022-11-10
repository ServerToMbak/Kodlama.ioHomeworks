using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository =programingLanguageRepository;
        }
        public async Task LanguageConNotBeDuplicatedWhenInserted(string name)
        {
         IPaginate<ProgramingLanguage>  result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())  throw new BusinessException("This programing languaga is already exist."); 
        }
    }
}
