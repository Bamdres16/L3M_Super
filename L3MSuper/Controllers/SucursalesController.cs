using L3MSuper.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    /// <summary>
    /// Controlador para las peticiones de la tabla de sucursales
    /// </summary>
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
            // Obtenemos toda la lista de sucursales de la base de datos
            var listado = BD.Sucursales.ToList();
            
            return listado;
        }
        /// <summary>
        /// Metodo POST que añade una nueva sucursal
        /// </summary>
        [HttpPost]
        public string Post(Sucursales elemento)
        {

            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
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
        /// <summary>
        /// Elimina una sucursal
        /// </summary>
        /// <param name="elemento"> Recibe un json (Body) con los keys de sucursales para eliminar</param>
        /// <returns>Un string de operacion</returns>
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
        /// <summary>
        /// Metodo para modificar una tabla existente
        /// </summary>
        /// <param name="elemento">Recibe un json (Body) con los keys nuevos de sucursales para eliminar</param>
        /// <param name="nombre"> La llave primaria que va a ser modificada </param>
        /// <returns>Un string de operacion</returns>
        [HttpPut]
        public string Put(Sucursales elemento, string nombre)
        {
            if (BD.Sucursales.Any(info => info.Nombre == nombre))
            {

                var wc = BD.Sucursales.First(p => p.Nombre == nombre);
                BD.Sucursales.Remove(wc);
                BD.SaveChanges();
                if (BD.Sucursales.Any(info => info.Nombre == elemento.Nombre))
                {
                    return "Ya existe esa sucursal en la base de datos";
                }
                else
                {

                    
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
