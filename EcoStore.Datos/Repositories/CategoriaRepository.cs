using EcoStore.Datos.Context;
using EcoStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Datos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            return await _context.Categorias
                .OrderBy(c => c.Nombre)
                .ToListAsync();
        }
    }
}