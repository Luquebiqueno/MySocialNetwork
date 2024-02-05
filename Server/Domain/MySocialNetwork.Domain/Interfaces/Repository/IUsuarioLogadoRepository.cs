using MySocialNetwork.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Repository
{
    public interface IUsuarioLogadoRepository
    {
        UsuarioIdentity GetUsuarioLogado(string identity);
        Task<UsuarioIdentity> GetUsuarioLogadoAsync(string identity);
    }
}
