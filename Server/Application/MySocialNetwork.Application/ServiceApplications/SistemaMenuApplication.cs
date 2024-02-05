using MySocialNetwork.Common.Application;
using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Dtos;
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
    public class SistemaMenuApplication<TContext> : ApplicationBase<TContext, SistemaMenu, int>, ISistemaMenuApplication<TContext>
                                   where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly ISistemaMenuService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public SistemaMenuApplication(IUnitOfWork<TContext> context,
                                      ISistemaMenuService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<List<SistemaMenuDto>> GetMenu()
            => await _service.GetMenu();

        #endregion
    }
}
