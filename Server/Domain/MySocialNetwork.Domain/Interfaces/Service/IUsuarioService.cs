using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Service
{
    public interface IUsuarioService<TContext> : IServiceBase<TContext, Usuario, int>
                                where TContext : IUnitOfWork<TContext>
    {
        Task<Usuario> UpdateUsuarioAsync(int id, Usuario entity);
        Task DeleteUsuarioAsync();
        Task AlterarSenhaAsync(string senha);
        Task<Usuario> GetUsuarioAutenticacaoAsync(string login, string senha);
        Task<Usuario> GetUsuarioLogadoAsync();
    }
}
