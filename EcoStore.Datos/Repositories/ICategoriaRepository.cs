using EcoStore.Entidades;

namespace EcoStore.Datos.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListarAsync();
    }
}