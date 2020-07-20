using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.WebAPI.Dtos
{
    public class EmprestimoDto
    {
        public int EmprestimoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int Id { get; set; }
        public int LivroId { get; set; }
        public LivroDto Livro { get; set; }
    }
}
