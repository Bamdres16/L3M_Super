
using L3MSuper.Class;
using L3MSuper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace L3MSuper.Controllers
{
    public class TrabajadoresController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        [HttpGet]
        public IEnumerable<Trabajadores> Get()

        {


            return BD.Trabajadores.ToList();
        
        }
        [HttpPost]
        public string Post(int Cedula, string Nombre_Completo, string Fecha_Nacimiento, string Fecha_Ingreso, string Sucursal, int Salario)
        {
            Trabajadores elemento = new Trabajadores();
            elemento.Cedula = Cedula;
            elemento.Nombre_Completo = Nombre_Completo;
            elemento.Fecha_de_Nacimiento = Convert.ToDateTime(Fecha_Nacimiento);
            elemento.Fecha_de_Ingreso = Convert.ToDateTime(Fecha_Ingreso);
            elemento.Sucursal = Sucursal;
            elemento.Salario_por_hora = Salario;
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
        public string Delete(int Cedula)
        {

            if (BD.Trabajadores.Any(info => info.Cedula == Cedula))
            {

                var wc = BD.Trabajadores.First(p => p.Cedula == Cedula);
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
        public string Put(int Cedula, string Nombre_Completo, string Fecha_Nacimiento, string Fecha_Ingreso, string Sucursal, int Salario, int actual)
        {
            if (BD.Trabajadores.Any(info => info.Cedula == actual))
            {
                Trabajadores elemento = new Trabajadores();
                elemento.Cedula = Cedula;
                elemento.Nombre_Completo = Nombre_Completo;
                elemento.Fecha_de_Nacimiento = Convert.ToDateTime(Fecha_Nacimiento);
                elemento.Fecha_de_Ingreso = Convert.ToDateTime(Fecha_Ingreso);
                elemento.Sucursal = Sucursal;
                elemento.Salario_por_hora = Salario;
                var wc = BD.Trabajadores.First(p => p.Cedula == actual);
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
