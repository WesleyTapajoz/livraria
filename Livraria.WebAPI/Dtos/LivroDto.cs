using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.WebAPI.Dtos
{
    public class LivroDto
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string ImagemURL { get; set; }
    }
}
