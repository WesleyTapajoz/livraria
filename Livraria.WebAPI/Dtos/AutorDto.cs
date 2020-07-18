using System.Collections.Generic;

namespace Livraria.WebAPI.Dtos
{
    public class AutorDto
    {
        public int AutorId { get; set; }
        public int UsuarioId { get; set; }
        public List<LivroDto> Livros { get; set; }
    }
}
