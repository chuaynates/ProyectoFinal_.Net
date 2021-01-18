using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }

        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public string NombreVendedor { get; set; }

        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public double IGV { get; set; }
        [Required]
        public double subTotal { get; set; }
        [Required]
        public double Total { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
    

