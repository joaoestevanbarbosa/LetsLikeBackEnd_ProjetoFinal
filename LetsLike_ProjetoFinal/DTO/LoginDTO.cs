using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
