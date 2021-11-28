using AutoMapper;
using LetsLike_ProjetoFinal.DTO;
using LetsLike_ProjetoFinal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LetsLike_ProjetoFinal.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        //[Authorize]
            private readonly IUsuarioService _usuarioService;
            private readonly IMapper _mapper;

            public LoginController(IUsuarioService usuarioService, IMapper mapper)
            {
                _usuarioService = usuarioService;
                _mapper = mapper;
            }

             // Post api/login
            /// <summary>
            ///     Valida usuário email/senha
            /// </summary>
            /// <returns>Usuários cadastrados na base de dados</returns>
            /// <response code="200">Se usuário email/senha estão corretos</response>
            /// <response code="404">Se email/senha não conferem</response>    
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<bool> Login([FromBody] LoginDTO value)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var findUser = _usuarioService.FindByUserName(value.Username);

                if (findUser == null)
                {
                    return NotFound();
                 }
             
                var verify = _usuarioService.VerifyPassword(value.Senha, findUser.Id);

                return Ok(verify); /// <returns>Usuários cadastrados na base de dados</returns>

            }
    }
}
