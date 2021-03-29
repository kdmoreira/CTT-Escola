using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.DTO
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Turma { get; set; }
    }
}
