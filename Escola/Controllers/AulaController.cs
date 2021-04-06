using AutoMapper;
using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.API.DTO;
using System.Collections.Generic;

namespace Escola.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IAulaRepository _repoAula;
        private readonly IMapper _mapper;

        public AulaController(IAulaRepository repo, IMapper mapper)
        {
            _repoAula = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as aulas registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aula
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<AulaController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                List<Aula> aulas = _repoAula.SelecionarTudoCompleto();
                return Ok(_mapper.Map<IEnumerable<AulaDto>>(aulas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna uma aula pelo id.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aula/id
        /// </remarks>
        /// <response code="200">Retorna a aula com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<AulaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                Aula aula = _repoAula.Selecionar(id);
                return Ok(_mapper.Map<AulaDto>(aula));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui uma nova aula.
        /// </summary>
        /// <param name="aula">Dados da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/aula
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="400">Se o Assunto da aula não for informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<AulaController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Aula aula)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                _repoAula.Incluir(aula);
                List<Aula> aulas = _repoAula.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<AulaDto>>(aulas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados da aula pelo id informado.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <param name="aula">Dados da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/aula/id
        /// </remarks>
        /// <response code="200">Altera a aula.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<AulaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Aula aula)
        {
            try
            {
                _repoAula.Alterar(aula);
                List<Aula> aulas = _repoAula.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<AulaDto>>(aulas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta uma aula pelo id.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/aula/id
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<AulaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repoAula.Excluir(id);
                List<Aula> aulas = _repoAula.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<AulaDto>>(aulas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
