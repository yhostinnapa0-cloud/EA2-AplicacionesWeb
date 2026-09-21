using EcoStore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoStore.Datos.Repositories
{
        public interface IProductoRepository
        {
            Task<List<Producto>> ListarAsync();
            Task CrearAsync(Producto producto);
            Task<Producto?> ObtenerPorIdAsync(int id);
            Task EditarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
    }

