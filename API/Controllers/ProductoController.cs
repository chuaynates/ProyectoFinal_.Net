using API.Models;
using API.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class ProductoController : ApiController
    {
        ProductoService Service;

        public StudentController()
        {
            Service = new ProductoService();
        }

        [HttpGet]
        public JsonResult<List<ProductoModel>> GetAllProductos()
        {
            EntityMapper<Producto, ProductoModel> mapObj = new EntityMapper<Producto, ProductoModel>();

            List<Producto> productoList = Service.Get();
            List<ProductoModel> Productos = new List<ProductoModel>();

            foreach (var item in productoList)
            {
                Productos.Add(mapObj.Translate(item));

            }

            return Json<List<ProductoModel>>(Productos);

        }

        [HttpGet]
        public JsonResult<ProductoModel> GetProducto(int Id)
        {
            EntityMapper<Producto, ProductoModel> mapObj = new EntityMapper<Producto, ProductoModel>();

            Producto dalProducto = Service.GetById(Id);
            ProductoModel Producto = new ProductoModel();
            Producto = mapObj.Translate(dalProducto);

            return Json<ProductoModel>(Producto);

        }

        [HttpGet]
        public JsonResult<List<StudentModel>> BusquedaStudents(string nombre)
        {
            EntityMapper<Producto, ProductoModel> mapObj = new EntityMapper<Producto, ProductoModel>();

            List<Producto> productoList = Service.Busqueda(nombre);
            List<ProductoModel> Productos = new List<ProductoModel>();

            foreach (var item in productoList)
            {
                Productos.Add(mapObj.Translate(item));

            }

            return Json<List<ProductoModel>>(Productos);

        }

        [HttpPost]
        public bool InsertProducto(ProductoModel Producto)
        {

            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<ProductoModel, Producto> mapObj = new EntityMapper<ProductoModel, Producto>();
                Producto ProductoObj = new Producto();
                ProductoObj = mapObj.Translate(Producto);
                Service.Insert(ProductoObj);
                status = true;
            }

            return status;

        }

        [HttpPut]
        public bool UpdateProducto(ProductoModel Producto)
        {

            bool status = false;
            EntityMapper<ProductoModel, Producto> mapObj = new EntityMapper<ProductoModel, Producto>();
            Producto ProductoObj = new Producto();
            ProductoObj = mapObj.Translate(Producto);
            Service.Update(ProductoObj);
            status = true;
            return status;

        }

        [HttpDelete]
        public bool DeleteProducto(int id)
        {

            bool status = false;
            Service.Delete(id);
            status = true;
            return status;

        }
    }
}

