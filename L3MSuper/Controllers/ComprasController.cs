using L3MSuper.Class;
using L3MSuper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    public class ComprasController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        [HttpGet]
        public IEnumerable<Compras> Get()

        {


            return BD.Compras.ToList();


        }

        [HttpPost]
        public string Post(string Descripcion, string Fecha_real, string Fecha_registro, string Proveedor, Byte[] foto, string Sucursal)
        {
            Random random = new Random();
            int uniqueId = random.Next(0, 10000);
            Compras elemento = new Compras();
            elemento.Descripcion = Descripcion;
            elemento.Fecha_Real = Convert.ToDateTime(Fecha_real);
            elemento.Fecha_Registro = Convert.ToDateTime(Fecha_registro);
            elemento.Proveedor = Proveedor;
            elemento.Foto = foto;
            elemento.Sucursal = Sucursal;
            elemento.Id_Compra = uniqueId;
            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Compras.Any(info => info.Id_Compra == elemento.Id_Compra))
            {
                return "Ya existe ese id de compra en la base de datos";
            }
            else
            {

                BD.Compras.Add(elemento);
                BD.SaveChanges();
                return "Compra añadida";
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {

            if (BD.Compras.Any(info => info.Id_Compra == id))
            {

                var wc = BD.Compras.First(p => p.Id_Compra == id);
                BD.Compras.Remove(wc);
                BD.SaveChanges();
                return "Compra eliminada";
            }
            else
            {
                return "Ese id de compra no existe";
            }
        }

        [HttpPut]
        public string Put(string Descripcion, string Fecha_real, string Fecha_registro, string Proveedor, Byte[] foto, string Sucursal, int actual)
        {
            if (BD.Compras.Any(info => info.Id_Compra == actual))
            {
                Compras elemento = new Compras();
                elemento.Descripcion = Descripcion;
                elemento.Fecha_Real = Convert.ToDateTime(Fecha_real);
                elemento.Fecha_Registro = Convert.ToDateTime(Fecha_registro);
                elemento.Proveedor = Proveedor;
                elemento.Foto = foto;
                elemento.Sucursal = Sucursal;
                elemento.Id_Compra = actual;
                var wc = BD.Compras.First(p => p.Id_Compra == actual);
                BD.Compras.Remove(wc);
                BD.SaveChanges();
                if (BD.Compras.Any(info => info.Id_Compra == elemento.Id_Compra))
                {
                    return "Ya existe ese id de compra en la base de datos";
                }
                else
                {
                    BD.Compras.Add(elemento);
                    BD.SaveChanges();
                    return "Id compra modificado";
                }

            }
            else
            {
                return "Ese id de compra no existe";
            }
        }
    }
}
