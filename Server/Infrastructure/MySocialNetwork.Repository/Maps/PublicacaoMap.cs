using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySocialNetwork.Common.Infrastructure.Map;
using MySocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Repository.Maps
{
    public class PublicacaoMap : EntityBaseMap<Publicacao, long>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Publicacao> builder)
        {
            builder.ToTable("Publicacao", "dbo");
            builder.Property(x => x.Id).HasColumnName("PublicacaoId").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Texto).HasColumnName("Texto").HasColumnType("varchar").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(x => x.UsuarioCadastro).HasColumnName("UsuarioCadastro").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").HasDefaultValue(true).IsRequired();
        }
    }
}
