using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface ITurmaAlunoRepository : IBaseRepository<TurmaAluno>
    {
        List<TurmaAluno> SelecionarTudoCompleto();
    }
}
