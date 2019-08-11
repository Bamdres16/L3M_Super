using L3MSuper.Datos.Modelo;
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
        Entities BD = new Entities();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        //public IEnumerable<Roles> Get()
        public int Get ()
        {
            //var listado = BD.Roles.ToList();
            return 5;

        }
    }
}
