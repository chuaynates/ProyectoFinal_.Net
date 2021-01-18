using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProductoModel
    {
        public int ProductoID { get; set; }

        public string Codigo { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }
    }
}