using MySocialNetwork.Common.Application;
using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.ServiceApplications
{
    public class PublicacaoApplication<TContext> : ApplicationBase<TContext, Publicacao, long>, IPublicacaoApplication<TContext>
                                  where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IPublicacaoService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public PublicacaoApplication(IUnitOfWork<TContext> context, 
                                     IPublicacaoService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task DeletePublicacaoAsync(long id)
        {
            await _service.DeletePublicacaoAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Publicacao> UpdatePublicacaoAsync(long id, Publicacao entity)
        {
            await _service.UpdatePublicacaoAsync(id, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        #endregion
    }
}
