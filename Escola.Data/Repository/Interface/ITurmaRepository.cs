using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        List<Turma> SelecionarTudoCompleto();
    }
}
