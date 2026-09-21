using EcoStore.Datos.Repositories;
using EcoStore.Entidades;

namespace EcoStore.Negocio.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            return await _repository.ListarAsync();
        }
    }
}