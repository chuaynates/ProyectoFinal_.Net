using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        public List<Producto> Get()
        {
            List<Producto> productos = null;
            using (var context = new SchoolContext())
            {
                productos = context.Productos.ToList();
            }

            return productos;
        }

        public Producto GetById(int ID)
        {
            Producto producto = null;
            using (var context = new SchoolContext())
            {

                producto = context.Productos.Find(ID);

            }

            return producto;
        }

        public void Insert(Producto producto)
        {
            using (var context = new SchoolContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();

            }
        }

        public void Update(Producto productoNew)
        {
            using (var context = new SchoolContext())
            {
                var producto = new Producto();
                producto = context.Productos.Find(productoNew.ProductoID);

                producto.Codigo = productoNew.Codigo;
                producto.Precio = productoNew.Precio;
                producto.Cantidad = productoNew.Cantidad;
                context.SaveChanges();

            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {

                var producto = context.Productos.Find(ID);
                context.Productos.Remove(producto);
                context.SaveChanges();

            }
        }



    }
}
