using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Data.Repository
{
    public class TurmaProfessorRepository : BaseRepository<TurmaProfessor>, ITurmaProfessorRepository
    {
        public TurmaProfessorRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<TurmaProfessor> SelecionarTudoCompleto()
        {
            return _contexto.TurmaProfessor
                .Include(x => x.Professor)
                .Include(x => x.Turma)
                .ToList();
        }
    }
}
