using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Models;
using MySocialNetwork.Domain.Dtos;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Repository.Context;

namespace MySocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IPublicacaoApplication<MySocialNetworkContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public PublicacaoController(IPublicacaoApplication<MySocialNetworkContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetPublicacao()
            => Ok(await _application.GetAllAsync());


        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetPublicacaoByIdAsync(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var publicacao = await _application.GetByIdAsync(id);
            if (publicacao == null)
                return NotFound();

            return Ok(publicacao);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> CreatePublicacaoAsync([FromBody] PublicacaoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            return Ok(await _application.CreateAsync(model.Model()));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdatePublicacaoAsync([FromRoute] int id, [FromBody] PublicacaoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            return Ok(await _application.UpdatePublicacaoAsync(id, model.Model()));

        }

        [HttpPut]
        [Route("DeletePublicacao/{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeletePublicacaoAsync(long id)
        {
            await _application.DeletePublicacaoAsync(id);
            return Ok();
        }

        #endregion
    }
}
