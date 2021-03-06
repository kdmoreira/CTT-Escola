using AutoMapper;
using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoEscola.API.DTO;
using System.Collections.Generic;

namespace Escola.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;
        // Caso queiramos monitorar nosso TurmaController (note no construtor também):
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TurmaController(ITurmaRepository repo, ILogger<TurmaController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as turmas registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turma
        /// </remarks>
        /// <response code="200">Retorna todas as turmas.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<TurmaController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            // Uma recomendação é loggar o que importa, como as exceções
            try
            {
                List<Turma> turmas = _repo.SelecionarTudoCompleto();
                return Ok(_mapper.Map<IEnumerable<TurmaDto>>(turmas));
            }
            catch (System.Exception ex)
            {
                // Exemplo de uso do logger:
                _logger.LogError(ex, "Erro ao recuperar todas as turmas.");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna uma turma pelo id.
        /// </summary>
        /// <param name="id">Identificador da turma.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turma/id
        /// </remarks>
        /// <response code="200">Retorna a turma com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                Turma turma = _repo.Selecionar(id);
                return Ok(_mapper.Map<TurmaDto>(turma));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui uma nova turma.
        /// </summary>
        /// <param name="turma">Dados da turma.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/turma
        /// </remarks>
        /// <response code="200">Retorna todas as turmas.</response>
        /// <response code="400">Se Curso ou Edição não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<TurmaController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Turma turma)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                _repo.Incluir(turma);
                List<Turma> turmas = _repo.SelecionarTudo();
                return Ok(_mapper.Map<TurmaDto>(turmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados da turma pelo id informado.
        /// </summary>
        /// <param name="id">Identificador da turma.</param>
        /// <param name="turma">Dados da turma.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/turma/id
        /// </remarks>
        /// <response code="200">Altera os dados da turma.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Turma turma)
        {
            try
            {
                _repo.Alterar(turma);
                List<Turma> turmas = _repo.SelecionarTudo();
                return Ok(_mapper.Map<TurmaDto>(turmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }           
        }

        /// <summary>
        /// Deleta uma turma pelo id.
        /// </summary>
        /// <param name="id">Identificador da turma.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/turma/id
        /// </remarks>
        /// <response code="200">Retorna todas as turmas.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Excluir(id);
                List<Turma> turmas = _repo.SelecionarTudo();
                return Ok(_mapper.Map<TurmaDto>(turmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
