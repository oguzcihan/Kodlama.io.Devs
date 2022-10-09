using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            LanguageCreatedDto resultLanguageDto = await Mediator.Send(createLanguageCommand);
            return Created("", resultLanguageDto); //data ya ulaşmak için api linkini de verebiliriz şimdilik boş
        }
        /// <summary>
        /// List method
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        /// <summary>
        /// GetById Method
        /// </summary>
        /// <param name="getByIdLanguageQuery"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            LanguageDeletedDto resultDeleteDto = await Mediator.Send(deleteLanguageCommand);
            return Ok(resultDeleteDto);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            LanguageUpdatedDto resultUpdatedDto = await Mediator.Send(updateLanguageCommand);
            return Ok(resultUpdatedDto);
        }

    }

   
}
