using Application.Features.ProgramingLanguages.Commands.CreateLanguages;
using Application.Features.ProgramingLanguages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesContoller : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguagesDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }
    }
}
