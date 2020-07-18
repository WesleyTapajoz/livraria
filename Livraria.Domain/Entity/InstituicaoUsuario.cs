using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class InstituicaoUsuario
    {
        public int InstituicaoUsuarioId { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
        public int Id { get; set; }
        public User User { get; set; }
        public bool Ativo { get; set; }
    }
}
