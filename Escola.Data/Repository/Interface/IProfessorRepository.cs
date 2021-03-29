using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        List<Professor> SelecionarTudoCompleto();
    }
}
