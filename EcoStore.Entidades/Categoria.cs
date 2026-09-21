using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcoStore.Entidades
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; } = string.Empty;

        // Relación: una categoría puede tener muchos productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
