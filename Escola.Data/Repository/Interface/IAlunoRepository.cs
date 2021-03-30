using Escola.Domain;
using System.Collections.Generic;

namespace Escola.Data.Interface
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        List<Aluno> SelecionarAlunos(string nome);
        Aluno SelecionarPorCpf(string cpf);
        string AlterarAluno(Aluno aluno);
        string IncluirAluno(Aluno aluno);
    }
}
