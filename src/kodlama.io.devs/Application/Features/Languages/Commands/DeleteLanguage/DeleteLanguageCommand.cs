using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<LanguageDeletedDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageHandler : IRequestHandler<DeleteLanguageCommand, LanguageDeletedDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;
            public DeleteLanguageHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageDeletedDto> Handle(DeleteLanguageCommand request,
                CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(l => l.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistsWhenRequested(language);

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language deleteLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                LanguageDeletedDto languageDeleteDto = _mapper.Map<LanguageDeletedDto>(deleteLanguage);
                return languageDeleteDto;
            }
        }
    }
}
