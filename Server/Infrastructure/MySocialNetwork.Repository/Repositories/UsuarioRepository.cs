using Microsoft.EntityFrameworkCore;
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
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario, int>, IUsuarioRepository<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        public UsuarioRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
            => await _dbSet.Where(x => x.Ativo).ToListAsync();
        public override async Task<Usuario> GetByIdAsync(int id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Ativo);
        public async Task<Usuario> GetUsuarioAutenticacaoAsync(string login, string senha)
            => await _dbSet.FirstOrDefaultAsync(x => (x.Email.Equals(login) || x.Telefone.Equals(login)) && x.Senha.Equals(senha) && x.Ativo);
        public Usuario UpdateUsuario(Usuario entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = _dbSet.Attach(entity);
                    result.State = EntityState.Modified;
                    result.Property(x => x.DataCadastro).IsModified = false;

                    return entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
