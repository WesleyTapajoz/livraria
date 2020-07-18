using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.WebAPI.Dtos
{
    public class InstituicaoEnsinoDto
    {
        public int InstituicaoEnsinoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPNJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
