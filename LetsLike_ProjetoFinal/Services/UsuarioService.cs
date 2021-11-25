using LetsLike_ProjetoFinal.Data;
using LetsLike_ProjetoFinal.Interfaces;
using LetsLike_ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Services
{
    public class UsuarioService : IUsuarioService
    {
        public LetsLikeContest _contexto;
        public UsuarioService(LetsLikeContest contexto)
        {
            _contexto = contexto;
        }

        public IList<Usuario> FindAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario SaveOrUpdate(Usuario usuario)
        {
            //TODO se eu estou salvando e atualizando no mesmo método
            //a primeira coisa que preciso verificar é se o usuário do parâmetro existe

            var existe = _contexto.Usuarios.Where(x => x.Id.Equals(usuario.Id)).FirstOrDefault();

            if (existe ==null)
            {
                _contexto.Usuarios.Add(usuario);
            }
            else
            {
                existe.Nome = usuario.Nome;
                existe.Username = usuario.Username;
                existe.Senha = usuario.Senha;
                existe.Email = usuario.Email;
            }
            _contexto.SaveChanges();

            return usuario;
        }

    }
}
