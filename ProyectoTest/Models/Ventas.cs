using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTest.Models
{
    public class Ventas
    {
        public int ID_Usuario { get; set; }
        public int ID_Compra { get; set; }
        public string ProDesc { get; set; }
        public decimal Total { get; set; }
        public string Comprador { get; set; }
        public string Telefono { get; set; }
        public string Fecha { get; set; }   
        public int ID_Estado { get; set; }

    }
}