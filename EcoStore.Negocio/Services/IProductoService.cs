using EcoStore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoStore.Negocio.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ListarAsync();
        Task CrearAsync(Producto producto);
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task EditarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
