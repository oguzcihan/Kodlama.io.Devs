using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand:IRequest<LanguageUpdatedDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand, LanguageUpdatedDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UpdateLanguageHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageUpdatedDto> Handle(UpdateLanguageCommand request,
                CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Language mappedLanguage = _mapper.Map<Language>(request);
                //Language? language = await _languageRepository.GetAsync(v => v.Id == request.Id);
                Language updatedLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
                LanguageUpdatedDto updateLanguageDto = _mapper.Map<LanguageUpdatedDto>(updatedLanguage);
                return updateLanguageDto;
            }
        }
    }
}
