namespace Escola.Domain
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        // Este Token faria diferença se na volta trouxéssemos o usuário inteiro de volta
        // public string Token { get; set; }
        public string Perfil { get; set; }
    }
}
