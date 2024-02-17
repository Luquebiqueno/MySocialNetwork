using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Common.Infrastructure.Context;
using MySocialNetwork.Repository.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository.Context
{
    public class MySocialNetworkContext : ContextBase<MySocialNetworkContext>
    {
        public MySocialNetworkContext(DbContextOptions<MySocialNetworkContext> options) : base(options) { }

        public new int Commit() => this.SaveChanges();
        public new async Task<int> CommitAsync() => await this.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SistemaMenuMap());
            modelBuilder.ApplyConfiguration(new PublicacaoMap());
        }
    }
}
