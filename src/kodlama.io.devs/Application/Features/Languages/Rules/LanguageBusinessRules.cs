using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                //TODO:resources ile yapılacak
                throw new BusinessException("Programming language name already exists.");
            }
        }

        public void LanguageShouldExistsWhenRequested(Language language)
        {
            if (language == null)
            {
                throw new BusinessException("Requested language does not exists.");
            }
        }

    }
}
