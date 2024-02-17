using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;

namespace MySocialNetwork.Api.Models
{
    public class PublicacaoViewModel : IViewModel<Publicacao>
    {
        public long Id { get; set; }
        public required string Texto { get; set; }
        public Publicacao Model()
        {
            var publicacao = new Publicacao(this.Id, this.Texto);

            if (this.Id.Equals(0))
            {
                publicacao.Ativar();
                publicacao.AtualizarDataCadastro(DateTime.Now);
            }

            return publicacao;
        }
    }
}
