using L3MSuper.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    public class TrabajadoresController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        [HttpGet]
        public IEnumerable<Trabajadores> Get()
        {
            // Obtenemos toda la lista de sucursales de la base de datos
            var listado = BD.Trabajadores.ToList();
            return listado;
        }
        [HttpPost]
        public string Post(Trabajadores elemento)
        {

            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Trabajadores.Any(info => info.Cedula == elemento.Cedula))
            {
                return "Ya existe ese trabajador en la base de datos";
            }
            else
            {

                BD.Trabajadores.Add(elemento);
                BD.SaveChanges();
                return "Trabajador añadido";
            }


        }
        [HttpDelete]
        public string Delete(Trabajadores elemento)
        {

            if (BD.Trabajadores.Any(info => info.Cedula == elemento.Cedula))
            {

                var wc = BD.Trabajadores.First(p => p.Cedula == elemento.Cedula);
                BD.Trabajadores.Remove(wc);
                BD.SaveChanges();
                return "Trabajador eliminado";
            }
            else
            {
                return "Esa trabajador no existe";
            }
        }
        [HttpPut]
        public string Put(Trabajadores elemento, int cedula)
        {
            if (BD.Trabajadores.Any(info => info.Cedula == cedula))
            {

                var wc = BD.Trabajadores.First(p => p.Cedula == cedula);
                BD.Trabajadores.Remove(wc);
                BD.SaveChanges();
                if (BD.Trabajadores.Any(info => info.Cedula == elemento.Cedula))
                {
                    return "Ya existe ese trabajador en la base de datos";
                }
                else
                {


                    BD.Trabajadores.Add(elemento);
                    BD.SaveChanges();
                    return "El perfil del trabajador se modificó";
                }

            }
            else
            {
                return "Ese trabajador no existe";
            }
        }
    }
}
