using EcoStore.Datos.Context;
using EcoStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Datos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ValidarLoginAsync(string email, string password)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Email == email &&
                    u.Password == password);
        }
    }
}