using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Interfaces.Service
{
    public interface IAutenticacaoService<TContext> where TContext : IUnitOfWork<TContext>
    {
        Task<TokenDto> GetAutenticacao(string login, string senha);
    }
}
