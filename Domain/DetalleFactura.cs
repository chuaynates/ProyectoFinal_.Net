using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class DetalleFactura
    {  
        [Key]
        public int ID { get; set; }
        public virtual Factura factura  { get; set; }
        public virtual Producto producto { get; set; }
    }
}
