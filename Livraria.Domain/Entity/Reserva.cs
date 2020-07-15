using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entity
{
   public class Reserva
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataReserva { get; set; }

    }
}
