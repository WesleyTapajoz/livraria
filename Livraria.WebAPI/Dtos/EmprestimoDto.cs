using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.WebAPI.Dtos
{
    public class EmprestimoDto
    {
        public int EmprestimoId { get; set; }
        public DateTime DatInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UsuarioId { get; set; }
    }
}
