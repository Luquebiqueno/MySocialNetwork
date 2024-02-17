using MySocialNetwork.Common.Domain.Entities;
using MySocialNetwork.Common.Infrastructure.Utils.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Entities
{
    public class Publicacao : EntityBase<long>
    {
        #region [ Propriedades ]

        public string? Texto { get; protected set; }

        #endregion

        #region [ Construtor ]

        public Publicacao()
        {

        }

        public Publicacao(long id, string? texto)
        {
            AtualizarId(id);
            AtualizarTexto(texto);
        }

        #endregion

        #region [ Métodos ]

        public void AtualizarTexto(string? texto) => this.Texto = texto;

        #endregion
    }
}
