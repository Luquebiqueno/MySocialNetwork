using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Dtos;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.ServiceApplications
{
    public class AutenticacaoApplication<TContext> : IAutenticacaoApplication<TContext>
                                    where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoService<TContext> _autenticacaoService;
        protected readonly IUnitOfWork<TContext> _unitOfWork;

        #endregion

        #region [ Construtores ]

        public AutenticacaoApplication(IAutenticacaoService<TContext> autenticacaoService,
                                       IUnitOfWork<TContext> unitOfWork)
        {
            _autenticacaoService = autenticacaoService;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Métodos ]

        public async Task<TokenDto> GetAutenticacao(string login, string senha)
        {
            var tokenDto = await _autenticacaoService.GetAutenticacao(login, senha);

            await _unitOfWork.CommitAsync();

            return tokenDto;
        }

        #endregion
    }
}
