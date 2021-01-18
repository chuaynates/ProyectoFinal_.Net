using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetalleFacturaService
    {
        public List<DetalleFactura> Get()
        {
            List<DetalleFactura> detalleFacturas = null;
            using (var context = new SchoolContext())
            {
                detalleFacturas = context.DetalleFacturas.ToList();
            }

            return detalleFacturas;
        }

        public DetalleFactura GetById(int ID)
        {
            DetalleFactura detalleFactura = null;
            using (var context = new SchoolContext())
            {

                detalleFactura = context.DetalleFacturas.Find(ID);

            }

            return detalleFactura;
        }

        public void Insert(DetalleFactura detalleFactura)
        {
            using (var context = new SchoolContext())
            {
                context.DetalleFacturas.Add(detalleFactura);
                context.SaveChanges();

            }
        }

        public void Update(DetalleFactura detalleFacturaNew)
        {
            using (var context = new SchoolContext())
            {
                var detalleFactura = new DetalleFactura();
                detalleFactura = context.DetalleFacturas.Find(detalleFacturaNew.ID);
                detalleFactura.factura = detalleFacturaNew.factura;
                detalleFactura.producto = detalleFacturaNew.producto;
                context.SaveChanges();

            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {
                var detalleFactura = context.DetalleFacturas.Find(ID);
                context.DetalleFacturas.Remove(detalleFactura);
                context.SaveChanges();

            }
        }



    }
}
