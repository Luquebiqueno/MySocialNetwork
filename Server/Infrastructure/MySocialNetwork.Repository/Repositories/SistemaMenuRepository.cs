using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Common.Infrastructure.Repository;
using MySocialNetwork.Domain.Dtos;
using MySocialNetwork.Domain.Entities;
using MySocialNetwork.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository.Repositories
{
    public class SistemaMenuRepository<TContext> : RepositoryBase<TContext, SistemaMenu, int>, ISistemaMenuRepository<TContext>
                                  where TContext : IUnitOfWork<TContext>
    {
        public SistemaMenuRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }

        public async Task<List<SistemaMenuDto>> GetMenu()
        {
            var lista = await _dbSet.Include(x => x.Children.Where(w => w.Ativo).OrderBy(w => w.Ordem))
                                         .Where(y => y.Ativo && y.ParentId == null)
                                         .OrderBy(z => z.Ordem)
                                         .ToListAsync();

            return lista.Select(x => new SistemaMenuDto
                   {
                       Descricao = x.Descricao,
                       Icone = x.Icone,
                       RouterLink = x.RouterLink,
                       Children = x.Children.Any() ? x.Children.Select(y => new SistemaSubMenuDto
                       {
                           Descricao = y.Descricao,
                           Icone = y.Icone,
                           RouterLink = y.RouterLink
                       }).ToList() : null
                   }).ToList(); 
        }
    }
}
