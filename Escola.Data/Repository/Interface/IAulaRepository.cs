using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface IAulaRepository : IBaseRepository<Aula>
    {
        List<Aula> SelecionarTudoCompleto();
    }
}
