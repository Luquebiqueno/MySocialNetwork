using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository<TContext> : IRepositoryBase<TContext, Usuario, int>
                                   where TContext : IUnitOfWork<TContext>
    {
        Usuario UpdateUsuario(Usuario entity);
        Task<Usuario> GetUsuarioAutenticacaoAsync(string login, string senha);
    }
}
