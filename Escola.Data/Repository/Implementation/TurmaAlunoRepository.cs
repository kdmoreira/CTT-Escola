using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Data.Repository
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno>, ITurmaAlunoRepository
    {
        public TurmaAlunoRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<TurmaAluno> SelecionarTudoCompleto()
        {
            return _contexto.TurmaAluno
                .Include(x => x.Aluno)
                .Include(x => x.Turma)
                .ToList();
        }
    }
}
