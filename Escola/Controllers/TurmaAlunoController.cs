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
    public class TurmaAlunoController : ControllerBase
    {
        private readonly ITurmaAlunoRepository _repo;
        private readonly IMapper _mapper;

        public TurmaAlunoController(ITurmaAlunoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as TurmaAluno registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turmaaluno
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaAluno.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<TurmaAlunoController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                List<TurmaAluno> turmasAlunos = _repo.SelecionarTudoCompleto();
                return Ok(_mapper.Map<IEnumerable<TurmaAlunoDto>>(turmasAlunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna uma TurmaAluno pelo id.
        /// </summary>
        /// <param name="id">Identificador da TurmaAluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turmaaluno/id
        /// </remarks>
        /// <response code="200">Retorna a TurmaAluno com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<TurmaAlunoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                TurmaAluno turmaAluno = _repo.Selecionar(id);
                return Ok(_mapper.Map<TurmaAlunoDto>(turmaAluno));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui uma nova TurmaAluno.
        /// </summary>
        /// <param name="turmaAluno">Dados da TurmaAluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/turmaaluno
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaAluno.</response>
        /// <response code="400">Se houver algum erro na inclusão.</response>
        // POST api/<TurmaAlunoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] TurmaAluno turmaAluno)
        {
            try
            {
                _repo.Incluir(turmaAluno);
                List<TurmaAluno> turmasAlunos = _repo.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<TurmaAlunoDto>>(turmasAlunos));
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro.");
            }
            
        }

        /// <summary>
        /// Altera os dados da TurmaAluno pelo id informado.
        /// </summary>
        /// <param name="turmaAluno">Dados da TurmaAluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/turmaaluno/id
        /// </remarks>
        /// <response code="200">Altera os dados da TurmaAluno.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<TurmaAlunoController>/5
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] TurmaAluno turmaAluno)
        {
            try
            {
                _repo.Alterar(turmaAluno);
                List<TurmaAluno> turmasAlunos = _repo.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<TurmaAlunoDto>>(turmasAlunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }         
        }

        /// <summary>
        /// Deleta uma TurmaAluno pelo id.
        /// </summary>
        /// <param name="id">Identificador da TurmaAluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/turmaaluno/id
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaAluno.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<TurmaAlunoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Excluir(id);
                List<TurmaAluno> turmasAlunos = _repo.SelecionarTudo();
                return Ok(_mapper.Map<IEnumerable<TurmaAlunoDto>>(turmasAlunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
