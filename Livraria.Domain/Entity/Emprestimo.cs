using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

    }
}
