using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        List<Aluno> SelecionarTudoCompleto();
        List<Aluno> SelecionarNome(string nome);
        List<Aluno> SelecionarEmail(string email);
        string AlterarAluno(Aluno aluno);
        string IncluirAluno(Aluno aluno);
    }
}
