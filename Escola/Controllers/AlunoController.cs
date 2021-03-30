using AutoMapper;
using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.API.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // Aqui o controller todo precisa de autorização
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repoAluno;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoRepository repoAluno, IMapper mapper)
        {
            _repoAluno = repoAluno;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os alunos registrados.
        /// </summary>
        /// <param name="nome">Nome do aluno.</param>
        /// <param name="cpf">CPF do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aluno
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<AlunoController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        //[Authorize] // É possível aplicar autorização apenas para métodos também
        public IActionResult GetAll([FromQuery] string nome, string cpf)
        {
            try
            {
                if (cpf != null)
                {
                    Aluno aluno = _repoAluno.SelecionarPorCpf(cpf);
                    return Ok(_mapper.Map<AlunoDto>(aluno));
                }
                else
                {
                    List<Aluno> alunos = _repoAluno.SelecionarAlunos(nome);
                    return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Retorna um aluno pelo id.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aluno/id
        /// </remarks>
        /// <response code="200">Retorna o aluno com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [AllowAnonymous] // Mesmo com a controller pedindo autorização,
        // é possível liberar alguns métodos específicos
        public IActionResult Get(int id)
        {
            try
            {
                Aluno aluno = _repoAluno.Selecionar(id);
                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui um novo aluno.
        /// </summary>
        /// <param name="aluno">Dados do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/aluno
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="400">Se CPF ou Nome não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<AlunoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "marketing, manager")] // Se alguém não autorizado tentar acessar, ocorrerá um Forbidden
        // Também serve para a controller inteira
        public IActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                if (string.IsNullOrEmpty(aluno.Cpf) || string.IsNullOrEmpty(aluno.Nome))
                    return BadRequest("Cpf ou Nome não foram informados.");

                _repoAluno.IncluirAluno(aluno);
                List<Aluno> alunos = _repoAluno.SelecionarTudo();

                return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do aluno pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <param name="aluno">Dados do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/aluno/id
        /// </remarks>
        /// <response code="200">Altera os dados do aluno.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            try
            {
                _repoAluno.AlterarAluno(aluno);
                List<Aluno> alunos = _repoAluno.SelecionarTudo();

                return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um aluno pelo id.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/aluno/id
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repoAluno.Excluir(id);
                List<Aluno> alunos = _repoAluno.SelecionarTudo();

                return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
