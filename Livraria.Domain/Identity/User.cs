using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Livraria.Domain
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
