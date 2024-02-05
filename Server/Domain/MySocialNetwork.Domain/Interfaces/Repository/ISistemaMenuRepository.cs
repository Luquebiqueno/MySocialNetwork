using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Dtos;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Repository
{
    public interface ISistemaMenuRepository<TContext> : IRepositoryBase<TContext, SistemaMenu, int>
                                       where TContext : IUnitOfWork<TContext>
    {
        Task<List<SistemaMenuDto>> GetMenu();
    }
}
