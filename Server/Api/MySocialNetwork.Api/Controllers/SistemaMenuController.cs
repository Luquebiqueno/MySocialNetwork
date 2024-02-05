using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Repository.Context;

namespace MySocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaMenuController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly ISistemaMenuApplication<MySocialNetworkContext> _application;

        #endregion

        #region [ Contrutores ]

        public SistemaMenuController(ISistemaMenuApplication<MySocialNetworkContext> application)
        {
            _application = application;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetMenu()
        {
            var result = await _application.GetMenu();
            return Ok(result);
        }

        #endregion
    }
}
