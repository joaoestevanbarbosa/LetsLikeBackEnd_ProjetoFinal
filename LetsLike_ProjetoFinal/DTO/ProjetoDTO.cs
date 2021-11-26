using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.DTO
{
    public class ProjetoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string URL { get; set; }
        public string Imagem { get; set; }
        public int IdUsuarioCadastro { get; set; }
    }
}
