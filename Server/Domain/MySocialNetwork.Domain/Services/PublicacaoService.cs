using MySocialNetwork.Common.Domain.Exceptions;
using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Common.Domain.Service;
using MySocialNetwork.Domain.Entities;
using MySocialNetwork.Domain.Helpers;
using MySocialNetwork.Domain.Interfaces.Repository;
using MySocialNetwork.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Services
{
    public class PublicacaoService<TContext> : ServiceBase<TContext, Publicacao, long>, IPublicacaoService<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IPublicacaoRepository<TContext> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public PublicacaoService(IPublicacaoRepository<TContext> repository,
                                 IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override Task<Publicacao> CreateAsync(Publicacao entity)
        {
            entity.AtualizarUsuarioCadastro(_usuarioLogado.Usuario.Id);
            return base.CreateAsync(entity);
        }

        public async Task DeletePublicacaoAsync(long id)
        {
            var publicacao = await GetByIdAsync(id);

            publicacao.Inativar();
            publicacao.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);
            publicacao.AtualizarDataAlteracao(DateTime.Now);

            base.Update(publicacao);
        }

        public async Task<Publicacao> UpdatePublicacaoAsync(long id, Publicacao entity)
        {
            var publicacao = await GetByIdAsync(id);

            publicacao.AtualizarTexto(entity.Texto);
            publicacao.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);
            publicacao.AtualizarDataAlteracao(DateTime.Now);

            return base.Update(publicacao);
        }

        #endregion

    }
}
