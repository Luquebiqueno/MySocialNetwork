using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Models;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Repository.Context;

namespace MySocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoApplication<MySocialNetworkContext> _autenticacaoApplication;

        #endregion

        #region [ Contrutores ]

        public AutenticacaoController(IAutenticacaoApplication<MySocialNetworkContext> autenticacaoApplication)
        {
            _autenticacaoApplication = autenticacaoApplication;
        }

        #endregion

        #region [ Métodos ]

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetAutenticacao([FromBody] UsuarioLoginViewModel model)
        {
            if (model == null)
                return BadRequest("Invalid client request");

            var token = await _autenticacaoApplication.GetAutenticacao(model.Login, model.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        #endregion
    }
}
