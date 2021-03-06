using AutoMapper;
using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.API.DTO;
using ProjetoEscola.API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepo, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo ?? throw new ArgumentNullException("UsuarioRepository não pode ser nulo");
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepo.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<UsuarioDto>>(usuarios));
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui um novo usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/usuario
        /// </remarks>
        /// <response code="200">Registra o usuário.</response>
        /// <response code="400">Se Nome ou Senha não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {              
                if (!ModelState.IsValid)
                    return BadRequest();

                _usuarioRepo.Incluir(usuario);
                return Ok("Usuário salvo com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
