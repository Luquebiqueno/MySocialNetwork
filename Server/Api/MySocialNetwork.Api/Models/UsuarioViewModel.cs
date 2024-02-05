using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Domain.Entities;

namespace MySocialNetwork.Api.Models
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public required string Senha { get; set; }

        public Usuario Model()
        {
            var usuario = new Usuario(this.Id, this.Nome, this.Email, this.Telefone);

            if (this.Id.Equals(0))
            {
                usuario.AtualizarSenha(this.Senha);
                usuario.AtualizarDataCadastro(DateTime.Now);
                usuario.Ativar();
            }

            return usuario;
        }
    }
}
