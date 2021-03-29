using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.DTO
{
    public class AulaDto
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Professor { get; set; }
        public string Turma { get; set; }
    }
}
