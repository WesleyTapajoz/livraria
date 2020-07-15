using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class Autor : Usuario
    {
        public int AutorId { get; set; }
        public int LivroId { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
