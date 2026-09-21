using EcoStore.Entidades;

namespace EcoStore.Negocio.Services
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarLoginAsync(string email, string password);
    }
}