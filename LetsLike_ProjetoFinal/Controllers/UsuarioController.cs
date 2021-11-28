using AutoMapper;
using LetsLike_ProjetoFinal.Data;
using LetsLike_ProjetoFinal.DTO;
using LetsLike_ProjetoFinal.Interfaces;
using LetsLike_ProjetoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LetsLike_ProjetoFinal.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly LetsLikeContest _contexto;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, LetsLikeContest contexto)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _contexto = contexto;
        }
        // POST api/usuario
        /// <summary>
        ///     Cria um usuário na base de dados conforme informado no corpo da requisição
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/usuario
        ///     { 
        ///        "nome": "Maria da Silva",
        ///        "email": "mariasilva@provedor.com",
        ///        "username": "mariasilva",
        ///        "senha": "silva123",
        ///        "confirmaSenha": "silva123"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Usuário que foi inserido na base</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDTO> Post([FromBody] UsuarioDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = value.Nome,
                Username = value.Username,
                Email = value.Email,
                Senha = Utils.Utils.EncryptValue(value.Senha),
            };


            var response = _usuarioService.SaveOrUpdate(usuario);

            if(response != null)
            {
                response.Senha = Utils.Utils.DecryptValue(response.Senha);
                return Ok(response);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notFound = new NotFoundObjectResult(res);
                notFound.StatusCode = 400;
                notFound.Value = "Erro ao cadastrar o usuário";

                return NotFound(notFound);
            }
        }

        // GET api/usuarios
        /// <summary>
        /// Retorna todos os usúarios na base
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET api/usuario
        ///     { 
        ///        "nome": "Maria da Silva",
        ///        "email": "mariasilva@provedor.com",
        ///        "username": "mariasilva",
        ///        "senha": "silva123",        
        ///        "projetos: [
        ///        
        ///        ]
        ///        "usuarioLikeProjeto":[
        ///        
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Usuário inserido na base</returns>
        /// <response code="200">Retorna os usuários cadastrados na base</response>
        /// <response code="404">Retorna se  usuario não for encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var response = _usuarioService.FindAllUsuarios();

            if (response != null)
            {
                return Ok(response.Select(x => _mapper.Map<Usuario>(x)).ToList());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
