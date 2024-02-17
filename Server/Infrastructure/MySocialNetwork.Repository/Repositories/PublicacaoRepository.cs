using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Common.Infrastructure.Repository;
using MySocialNetwork.Domain.Entities;
using MySocialNetwork.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository.Repositories
{
    public class PublicacaoRepository<TContext> : RepositoryBase<TContext, Publicacao, long>, IPublicacaoRepository<TContext>
                                 where TContext : IUnitOfWork<TContext>
    {
        public PublicacaoRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }
    }
}
