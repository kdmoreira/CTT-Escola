using Escola.Domain;

namespace ProjetoEscola.API.DTO
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Turno { get; set; }
    }
}
