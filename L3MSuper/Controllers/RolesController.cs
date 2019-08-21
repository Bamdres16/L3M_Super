
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
    public class RolesController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        [HttpGet]
        public IEnumerable<Roles> Get()

        {


            return BD.Roles.ToList();


        }
        [HttpPost]
        public string Post(string Nombre, string Descripcion)
        {
            Roles elemento = new Roles();
            elemento.Descripcion = Descripcion;
            elemento.Nombre = Nombre;
            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Sucursales.Any(info => info.Nombre == elemento.Nombre))
            {
                return "Ya existe ese rol en la base de datos";
            }
            else
            {

                BD.Roles.Add(elemento);
                BD.SaveChanges();
                return "Rol añadido";
            }
        }
        [HttpPut]
        public string Put(string Nombre, string Descripcion, string nombre)
        {
            if (BD.Roles.Any(info => info.Nombre == nombre))
            {
                Roles elemento = new Roles();
                elemento.Descripcion = Descripcion;
                elemento.Nombre = Nombre;
                var wc = BD.Roles.First(p => p.Nombre == nombre);
                BD.Roles.Remove(wc);
                BD.SaveChanges();
                if (BD.Roles.Any(info => info.Nombre == elemento.Nombre))
                {
                    return "Ya existe rol en la base de datos";
                }
                else
                {

                    
                    BD.Roles.Add(elemento);
                    BD.SaveChanges();
                    return "Rol de " + elemento.Nombre + " modificado";
                }

            }
            else
            {
                return "Ese rol no existe";
            }
        }
        [HttpDelete]
        public string Delete(string Nombre)
        {

            if (BD.Roles.Any(info => info.Nombre == Nombre))
            {

                var wc = BD.Roles.First(p => p.Nombre == Nombre);
                BD.Roles.Remove(wc);
                BD.SaveChanges();
                return "Rol eliminado";
            }
            else
            {
                return "Ese rol no existe";
            }
        }
    }
}
