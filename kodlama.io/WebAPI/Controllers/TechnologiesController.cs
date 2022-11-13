using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetListBrand;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.Models;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.CreateTechnology;
using Application.Features.Technology.Dto;
using Application.Features.Technology.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateTechnologyCommand createdTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createdTechnologyCommand);
            return Created("", result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Created("", result);
        }
            
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdateTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Created("", result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GeListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }
    }
}
