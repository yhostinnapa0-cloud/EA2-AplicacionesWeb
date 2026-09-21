using EcoStore.Datos.Repositories;
using EcoStore.Entidades;

namespace EcoStore.Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario?> ValidarLoginAsync(string email, string password)
        {
            return await _repository.ValidarLoginAsync(email, password);
        }
    }
}