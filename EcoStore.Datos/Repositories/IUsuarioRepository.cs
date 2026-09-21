using System.Threading.Tasks;
using EcoStore.Entidades;

namespace EcoStore.Datos.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ValidarLoginAsync(string email, string password);
    }
}