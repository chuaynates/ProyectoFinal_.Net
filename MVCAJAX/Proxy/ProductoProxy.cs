using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using MVCAJAX.Models;

namespace MVCAJAX.Proxy
{
    public class ProductoProxy
    {
        public async Task<ResponseProxy<ProductoModel>> GetStudentsAsync()
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/GetAllStudents");
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<ProductoModel>>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = productos
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<ProductoModel>> GetByIdAsync(int id)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/GetStudent", "/", id);

            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<ProductoModel>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    objeto = producto
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<ProductoModel>> BuscarStudentsAsync(string dato)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/BusquedaStudents", "?nombre=", dato);

            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<ProductoModel>>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = productos
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<ProductoModel>> InsertAsync(ProductoModel model)
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/InsertStudent");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito",
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }


        public async Task<ResponseProxy<ProductoModel>> UpdateAsync(ProductoModel model)
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/UpdateStudent");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito",
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }

        public async Task<ResponseProxy<ProductoModel>> DeleteStudentAsync(int id)
        {

            var client = new HttpClient();
            var urlBase = "https://localhost:44363";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/api", "/Student", "/DeleteStudent", "/", id);

            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = exito,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                };

            }
            else
            {
                return new ResponseProxy<ProductoModel>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }

        }
    }
}