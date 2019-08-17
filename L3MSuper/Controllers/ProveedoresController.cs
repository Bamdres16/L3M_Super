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
    public class ProveedoresController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        [HttpGet]
        public IEnumerable<Proveedores> Get()

        {


            return BD.Proveedores.ToList();


        }

        [HttpPost]
        public string Post(Proveedores elemento)
        {

            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Proveedores.Any(info => info.Nombre_Completo == elemento.Nombre_Completo))
            {
                return "Ya existe ese proveedor en la base de datos";
            }
            else
            {

                BD.Proveedores.Add(elemento);
                BD.SaveChanges();
                return "Proveedor añadido";
            }
        }
        [HttpDelete]
        public string Delete(Proveedores elemento)
        {

            if (BD.Proveedores.Any(info => info.Nombre_Completo == elemento.Nombre_Completo))
            {

                var wc = BD.Proveedores.First(p => p.Nombre_Completo == elemento.Nombre_Completo);
                BD.Proveedores.Remove(wc);
                BD.SaveChanges();
                return "Proveedor eliminada";
            }
            else
            {
                return "Ese proveedor no existe";
            }
        }

        [HttpPut]
        public string Put(Proveedores elemento, string nombre)
        {
            if (BD.Proveedores.Any(info => info.Nombre_Completo == nombre))
            {

                var wc = BD.Proveedores.First(p => p.Nombre_Completo == nombre);
                BD.Proveedores.Remove(wc);
                BD.SaveChanges();
                if (BD.Proveedores.Any(info => info.Nombre_Completo == elemento.Nombre_Completo))
                {
                    return "Ya existe ese proveedor en la base de datos";
                }
                else
                {


                    BD.Proveedores.Add(elemento);
                    BD.SaveChanges();
                    return "Proveedor modificado";
                }

            }
            else
            {
                return "Ese proveedor no existe";
            }
        }

    }
}
