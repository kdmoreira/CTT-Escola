using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface ITurmaProfessorRepository : IBaseRepository<TurmaProfessor>
    {
        List<TurmaProfessor> SelecionarTudoCompleto();
    }
}
