using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Common.Domain.Service;
using MySocialNetwork.Domain.Dtos;
using MySocialNetwork.Domain.Entities;
using MySocialNetwork.Domain.Interfaces.Repository;
using MySocialNetwork.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Services
{
    public class SistemaMenuService<TContext> : ServiceBase<TContext, SistemaMenu, int>, ISistemaMenuService<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly ISistemaMenuRepository<TContext> _repository;

        #endregion

        #region [ Construtor ]

        public SistemaMenuService(ISistemaMenuRepository<TContext> repository) : base(repository)
        {
            _repository = repository;
        }

        #endregion

        #region [ Métodos ]

        public async Task<List<SistemaMenuDto>> GetMenu()
            => await _repository.GetMenu();

        #endregion
    }
}
