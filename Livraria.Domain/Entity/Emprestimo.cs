using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public DateTime DatInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UserId { get; set; }
    }
}
