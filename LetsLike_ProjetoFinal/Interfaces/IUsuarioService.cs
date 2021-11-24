using LetsLike_ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Interfaces
{
    interface IUsuarioService
    {
        Usuario SaveOrUpdate(Usuario usuario);
    }
}
