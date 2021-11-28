using LetsLike_ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Interfaces
{
    public interface IUsuarioService
    {
        Usuario SaveOrUpdate(Usuario usuario);
        IList<Usuario> FindByName(string nome);
        Usuario FindByUserName(string userName);
        Usuario FindByEmail(string email);
        bool VerifyPassword(string senha, int idusuario);
        // TODO a titulo de boas práticas não é bacana colocar o nome da Entidade no método
        // o mais correto neste caso seria chamá-lo de FindAll
        IList<Usuario> FindAllUsuarios();
    }
}
