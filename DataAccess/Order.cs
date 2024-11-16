using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Order
    {
        public int OrderID { get; set; }
        public string ShipName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }


        public int ProductID { get; set; }        // ID del producto
        public string ProductName { get; set; }   // Nombre del producto
        public int Quantity { get; set; }         // Cantidad pedida
        public decimal UnitPrice { get; set; }    // Precio unitario del producto
        public decimal Total { get; set; }        // Total calculado (UnitPrice * Quantity)


        public DateTime? ConfirmationDate { get; set; }  // Fecha de confirmación, puede ser null si no está confirmado
        public string Estado { get; set; }          // Estado del pedido (por ejemplo: 'Confirmado', 'No confirmado')
        public string Commments { get; set; }

    }
}