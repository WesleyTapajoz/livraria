using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int Endereço { get; set; }
        public int CPF { get; set; }
        public int Telefone { get; set; }
        public int EMail { get; set; }
    }
}
