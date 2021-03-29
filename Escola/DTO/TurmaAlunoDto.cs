using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.DTO
{
    public class TurmaAlunoDto
    {
        public int IdAluno { get; set; }
        public string Aluno { get; set; }
        public int IdTurma { get; set; }
        public string Turma { get; set; }
    }
}
