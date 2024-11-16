using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderUpdate
    {
        public int OrderID { get; set; }
        public DateTime? ConfirmationDate { get; set; }  // Fecha de confirmación, puede ser null si no está confirmado
        public string Estado { get; set; }          // Estado del pedido (por ejemplo: 'Confirmado', 'No confirmado')
        public string? Commments { get; set; }

    }
}