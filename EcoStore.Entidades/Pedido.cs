using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcoStore.Entidades
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }

        public string Estado { get; set; } = string.Empty;

        public decimal Total { get; set; }

        // Relación con Usuario
        public Usuario? Usuario { get; set; }

        // Relación: un pedido tiene varios detalles
        public ICollection<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>();
    }
}
