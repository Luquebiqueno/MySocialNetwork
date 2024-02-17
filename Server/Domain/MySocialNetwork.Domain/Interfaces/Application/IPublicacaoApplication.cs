using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Application
{
    public interface IPublicacaoApplication<TContext> : IApplicationBase<TContext, Publicacao, long>
                                       where TContext : IUnitOfWork<TContext>
    {
        Task<Publicacao> UpdatePublicacaoAsync(long id, Publicacao entity);
        Task DeletePublicacaoAsync(long id);
    }
}
