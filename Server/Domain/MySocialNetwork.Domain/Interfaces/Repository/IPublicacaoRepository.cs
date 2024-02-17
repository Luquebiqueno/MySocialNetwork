using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Repository
{
    public interface IPublicacaoRepository<TContext> : IRepositoryBase<TContext, Publicacao, long>
                                      where TContext : IUnitOfWork<TContext>
    {
    }
}
