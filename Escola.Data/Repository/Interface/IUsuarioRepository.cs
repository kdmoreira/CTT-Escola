using Escola.Domain;

namespace Escola.Data.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario SelecionarPorNomeESenha(string nome, string senha);
    }
}
