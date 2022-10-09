using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand:IRequest<LanguageCreatedDto>
    {
        public string Name { get; set; }

        public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, LanguageCreatedDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public CreateLanguageHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageCreatedDto> Handle(CreateLanguageCommand request,
                CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
                LanguageCreatedDto createLanguageDto = _mapper.Map<LanguageCreatedDto>(createdLanguage);
                return createLanguageDto;
            }
        }
    }
}
