using AutoMapper;
using LetsLike_ProjetoFinal.Data;
using LetsLike_ProjetoFinal.Interfaces;
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
    }
}
