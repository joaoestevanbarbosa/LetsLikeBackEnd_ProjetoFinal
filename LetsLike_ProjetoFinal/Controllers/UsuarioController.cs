using AutoMapper;
using LetsLike_ProjetoFinal.Data;
using LetsLike_ProjetoFinal.DTO;
using LetsLike_ProjetoFinal.Interfaces;
using LetsLike_ProjetoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                Senha = value.Senha,
            };


            var response = _usuarioService.SaveOrUpdate(usuario);

            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notFound = new NotFoundObjectResult(res);
                notFound.StatusCode = 500;
                notFound.Value = "Erro ao cadastrar o usuário";

                return NotFound(notFound);
            }
        }
    }
}
