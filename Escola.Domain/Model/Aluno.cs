using System.Collections.Generic;

namespace Escola.Domain
{
    public class Aluno : IEntity
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        
        public List<TurmaAluno> TurmaAluno { get; set; }
    }
}
