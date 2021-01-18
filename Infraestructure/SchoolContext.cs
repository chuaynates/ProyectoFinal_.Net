using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Infraestructure
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name= MyContextDB")
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas{ get; set; }
        public DbSet<DetalleFactura> DetalleFacturas{ get; set; }


    }
}
