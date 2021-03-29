using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.DTO
{
    public class TurmaProfessorDto
    {
        public int IdProfessor { get; set; }
        public string Professor { get; set; }
        public int IdTurma { get; set; }
        public string Turma { get; set; }
    }
}
