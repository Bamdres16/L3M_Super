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
    public class ControlController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        [HttpGet]
        public IEnumerable<Control> Get()

        {


            return BD.Control.ToList();

        }

        [HttpPost]
        public string Post(Control elemento)
        {

            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Control.Any(info => info.Cedula == elemento.Cedula))
            {
                return "Ya existe esa ficha de control en la base de datos";
            }
            else
            {

                BD.Control.Add(elemento);
                BD.SaveChanges();
                return "Ficha añadida";
            }
        }
        [HttpDelete]
        public string Delete(Control elemento)
        {

            if (BD.Control.Any(info => info.Cedula == elemento.Cedula))
            {

                var wc = BD.Control.First(p => p.Cedula == elemento.Cedula);
                BD.Control.Remove(wc);
                BD.SaveChanges();
                return "Ficha eliminada";
            }
            else
            {
                return "Esa ficha no existe";
            }
        }

        [HttpPut]
        public string Put(Control elemento, int id)
        {
            if (BD.Control.Any(info => info.Cedula == id))
            {

                var wc = BD.Control.First(p => p.Cedula == id);
                BD.Control.Remove(wc);
                BD.SaveChanges();
                if (BD.Control.Any(info => info.Cedula == elemento.Cedula))
                {
                    return "Ya existe esa ficha de control en la base de datos";
                }
                else
                {
                    BD.Control.Add(elemento);
                    BD.SaveChanges();
                    return "Ficha modificada";
                }

            }
            else
            {
                return "Esa ficha de control no existe";
            }
        }
    }
}
