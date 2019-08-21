
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


            return BD.Sucursales.ToList();


        }
        /// <summary>
        /// Metodo POST que añade una nueva sucursal
        /// </summary>
        [HttpPost]
        public string Post(string Nombre, string Direccion, int Telefono, string Administrador)
        {

            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Sucursales.Any(info => info.Nombre == Nombre))
            {
                return "Ya existe esa sucursal en la base de datos";
            }
            else
            {
                Sucursales elemento = new Sucursales();
                elemento.Nombre = Nombre;
                elemento.Direccion = Direccion;
                elemento.Telefono = Telefono;
                elemento.Administrador = Administrador;
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
        public string Delete(string Nombre)
        {
           
            if (BD.Sucursales.Any(info => info.Nombre == Nombre))
            {
                
                var wc= BD.Sucursales.First(p => p.Nombre == Nombre);
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
        public string Put(string actual, string Nombre, string Direccion, int Telefono, string Administrador)
        {
            if (BD.Sucursales.Any(info => info.Nombre == actual))
            {
                Sucursales elemento = new Sucursales();
                elemento.Nombre = Nombre;
                elemento.Direccion = Direccion;
                elemento.Telefono = Telefono;
                elemento.Administrador = Administrador;
                var wc = BD.Sucursales.First(p => p.Nombre == actual);
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
