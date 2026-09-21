using EcoStore.Entidades;

namespace EcoStore.Negocio.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ListarAsync();
    }
}