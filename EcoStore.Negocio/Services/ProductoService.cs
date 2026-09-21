using EcoStore.Entidades;
using EcoStore.Datos.Repositories;

namespace EcoStore.Negocio.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Producto>> ListarAsync()
        {
            return await _repository.ListarAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _repository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(Producto producto)
        {
            await _repository.CrearAsync(producto);
        }

        public async Task EditarAsync(Producto producto)
        {
            await _repository.EditarAsync(producto);
        }
        public async Task EliminarAsync(int id)
        {
            await _repository.EliminarAsync(id);
        }
    }
}