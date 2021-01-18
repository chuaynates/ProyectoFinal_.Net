using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FacturaService
    {
        public List<Factura> Get()
        {
            List<Factura> facturas = null;
            using (var context = new SchoolContext())
            {
                facturas = context.Facturas.ToList();
            }

            return facturas;
        }

        public Factura GetById(int ID)
        {
            Factura factura = null;
            using (var context = new SchoolContext())
            {
                factura = context.Facturas.Find(ID);

            }

            return factura;
        }


        /*public List<Factura> Busqueda(string NombreApellido)
        {
            List<Factura> facturas = null;
            using (var context = new SchoolContext())
            {
                facturas = context.Facturas.Where(x => x.Activo == true && x.StudentName.Contains(NombreApellido) || x.Activo == true && x.LastName.Contains(NombreApellido)).ToList();
            }

            return facturas;
        } */


        public void Insert(Factura factura)
        {
            using (var context = new SchoolContext())
            {
                context.Facturas.Add(factura);
                context.SaveChanges();
            }
        }

        public void Update(Factura facturaNew)
        {
            using (var context = new SchoolContext())
            {
                var student = new Factura();
                student = context.Facturas.Find(facturaNew.FacturaID);
                student.FechaFactura = facturaNew.FechaFactura;
                student.NombreVendedor = facturaNew.NombreVendedor;
                student.NombreCliente = facturaNew.NombreCliente;
                student.IGV = facturaNew.IGV;
                student.subTotal = facturaNew.subTotal;
                student.Total = facturaNew.Total;
                context.SaveChanges();

            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {

                var factura = context.Facturas.Find(ID);
                //factura.Activo = false;
                context.Facturas.Remove(factura);
                context.SaveChanges();

            }
        }
    }
}
