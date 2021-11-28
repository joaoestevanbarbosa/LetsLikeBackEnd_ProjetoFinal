using LetsLike_ProjetoFinal.Data;
using LetsLike_ProjetoFinal.Interfaces;
using LetsLike_ProjetoFinal.Models;
using LetsLike_ProjetoFinal.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var result = _contexto.Usuarios.Include(x => x.Projeto)
                            .ThenInclude(j => j.UsuarioCadastro)
                            .ToList();

            foreach (var item in result)
            {
                item.Senha = Utils.Utils.DecryptValue(item.Senha);
            }

            return result;
        }

        public Usuario FindByEmail(string email)
        {
            return _contexto.Usuarios.Where(x => x.Email == email).FirstOrDefault();
        }

        public IList<Usuario> FindByName(string nome)
        {
            return _contexto.Usuarios.Where(x => x.Nome == nome).ToList();
        }

        public Usuario FindByUserName(string userName)
        {
            return _contexto.Usuarios.Where(x => x.Username == userName).FirstOrDefault();
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

        public bool VerifyPassword(string senha, int idUsuario)
        {
            try
            {
                var find = _contexto.Usuarios.Where(x => x.Id == idUsuario).FirstOrDefault();

                if (find != null)
                {
                    var senhaDB = Utils.Utils.DecryptValue(find.Senha);

                    return senhaDB.Equals(senha);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
