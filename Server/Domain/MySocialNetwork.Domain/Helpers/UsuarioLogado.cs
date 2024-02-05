using Microsoft.AspNetCore.Http;
using MySocialNetwork.Common.Domain.Entities;
using MySocialNetwork.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Helpers
{
    public class UsuarioLogado : IUsuarioLogado
    {
        #region [ Propriedades ]

        private readonly IHttpContextAccessor _accessor;
        private readonly IUsuarioLogadoRepository _usuarioLogadoRepository;

        #endregion

        #region [ Construtores ]

        public UsuarioLogado(IHttpContextAccessor accessor,
                             IUsuarioLogadoRepository usuarioLogadoRepository)
        {
            _accessor = accessor;
            _usuarioLogadoRepository = usuarioLogadoRepository;
        }

        #endregion

        #region [ Métodos ]

        public UsuarioIdentity Usuario => _usuarioLogadoRepository.GetUsuarioLogado(_accessor.HttpContext.User.Identity.Name);

        #endregion
    }
}
