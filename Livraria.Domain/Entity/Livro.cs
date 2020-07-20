using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string ImagemURL { get; set; }
        public string Autor { get; set; }
        public bool Ativo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

    }
}
