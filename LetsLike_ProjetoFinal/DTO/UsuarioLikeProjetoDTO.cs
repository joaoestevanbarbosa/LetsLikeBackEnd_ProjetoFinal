using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.DTO
{
    public class UsuarioLikeProjetoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdUsuarioLike { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdProjetoLike { get; set; }
    }
}
