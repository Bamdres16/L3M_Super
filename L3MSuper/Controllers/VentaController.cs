using L3MSuper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    public class VentaController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        [HttpGet]
        public IEnumerable<Venta> Get()

        {


            return BD.Venta.ToList();


        }

        [HttpPost]
        public string Post(string Cajero, int Descuento, int Impuesto, string Productos, int Total)
        {
            Random random = new Random();
            int uniqueId = random.Next(0, 10000);
            
            Venta elemento = new Venta();
            elemento.Cajero = Cajero;
            elemento.Descuento = Descuento;
            elemento.Impuesto = Impuesto;
            elemento.Productos = Productos;
            elemento.Total = Total;
            elemento.Id_Venta = uniqueId;
            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Venta.Any(info => info.Id_Venta == elemento.Id_Venta))
            {
                return "Ya existe ese id de compra en la base de datos";
            }
            else
            {

                BD.Venta.Add(elemento);
                BD.SaveChanges();
                return "Venta añadida";
            }
        }
        [HttpDelete]
        public string Delete(int Id_Venta)
        {

            if (BD.Venta.Any(info => info.Id_Venta == Id_Venta))
            {

                var wc = BD.Venta.First(p => p.Id_Venta == Id_Venta);
                BD.Venta.Remove(wc);
                BD.SaveChanges();
                return "Venta eliminada";
            }
            else
            {
                return "Ese id de venta no existe";
            }
        }

        [HttpPut]
        public string Put(string Cajero, int Descuento, int Impuesto, string Productos, int Total, int actual)
        {

            if (BD.Venta.Any(info => info.Id_Venta == actual))
            {
               

                Venta elemento = new Venta();
                elemento.Impuesto = Impuesto;
                elemento.Descuento = Descuento;
                elemento.Productos = Productos;
                elemento.Total = Total;
                elemento.Cajero = Cajero;
                elemento.Id_Venta = actual;
                var wc = BD.Venta.First(p => p.Id_Venta == actual);
                BD.Venta.Remove(wc);
                BD.SaveChanges();
                if (BD.Venta.Any(info => info.Id_Venta == elemento.Id_Venta))
                {
                    return "Ya existe ese id de venta en la base de datos";
                }
                else
                {
                    BD.Venta.Add(elemento);
                    BD.SaveChanges();
                    return "Id venta modificado";
                }

            }
            else
            {
                return "Ese id de venta no existe";
            }
        }
    }
}
