using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
   public class InstituicaoEnsino
    {
        public int InstituicaoEnsinoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPNJ { get; set; }
        public string Telefone { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
    }
}
