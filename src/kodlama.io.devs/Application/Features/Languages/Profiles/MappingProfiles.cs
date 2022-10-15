using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //İkisi karşılaşırsa brand i dto ya çevir. reversemap ile tam tersi map te çalışır.

            #region Created Programming Language Name

            CreateMap<Language, LanguageCreatedDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            #endregion

            #region Pagination and GetById Language

            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();

            #endregion

            #region Deleted Language

            CreateMap<Language, LanguageDeletedDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();

            #endregion

            #region Updated Language

            CreateMap<Language, LanguageUpdatedDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();

            #endregion


        }
    }
}
