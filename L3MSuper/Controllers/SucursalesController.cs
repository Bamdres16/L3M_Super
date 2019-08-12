using L3MSuper.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    public class SucursalesController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        /// <summary>
        /// Metodo GET que permite obtener la lista de sucursales que existen.
        /// </summary>
        /// <returns>Lista en tipo JSON de las sucursales</returns>
        [HttpGet]
        public IEnumerable<Sucursales> Get()
        {
            var suc = BD.Sucursales.ToList();
            
            return suc;
        }
        /// <summary>
        /// Metodo POST que añade una nueva sucursal
        /// </summary>
        [HttpPost]
        public string Post(Sucursales elemento)
        {

            // Valida si existe un elemento dentro de la tabla
            if (BD.Sucursales.Any(info => info.Nombre == elemento.Nombre))
            {
                return "Ya existe esa sucursal en la base de datos";
            }
            else
            {
               
                BD.Sucursales.Add(elemento);
                BD.SaveChanges();
                return "Sucursal añadida";
            }
            
            
        }
        [HttpDelete]
        public string Delete(Sucursales elemento)
        {
           
            if (BD.Sucursales.Any(info => info.Nombre == elemento.Nombre))
            {
                
                var wc= BD.Sucursales.First(p => p.Nombre == elemento.Nombre);
                BD.Sucursales.Remove(wc);
                BD.SaveChanges();
                return "Sucursal eliminada";
            }
            else
            {
                return "Esa sucursal no existe";
            }
        }
        [HttpPut]
        public string Put(Sucursales elemento, string nombre)
        {
            if (BD.Sucursales.Any(info => info.Nombre == nombre))
            {

                var wc = BD.Sucursales.First(p => p.Nombre == nombre);
                BD.Sucursales.Remove(wc);
                if (BD.Sucursales.Any(info => info.Nombre == elemento.Nombre))
                {
                    return "Ya existe esa sucursal en la base de datos";
                }
                else
                {

                    BD.SaveChanges();
                    BD.Sucursales.Add(elemento);
                    BD.SaveChanges();
                    return "Sucursal modificada";
                }
                
            }
            else
            {
                return "Esa sucursal no existe";
            }
        }
       
    }
}
