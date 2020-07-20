using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.WebAPI.Dtos
{ 
   public class ReservaDto
    {
        public int ReservaId { get; set; }
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public int LivroId { get; set; }
    }
}
