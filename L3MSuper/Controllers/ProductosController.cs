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
    public class ProductosController : ApiController
    {
        AdministrationConnection BD = new AdministrationConnection();
        // IEnumerable generica para retornar cualquier tipo
        // Metodo de tipo get para obtener todos los roles existentes
        [HttpGet]
        public IEnumerable<Productos> Get()

        {


            return BD.Productos.ToList();


        }


        [HttpPost]
        public string Post(int codigo, string nombre, string proveedor, int precio, bool impuesto,bool descuento,string sucursal,string descripcion)
        {
            Productos elemento = new Productos();
            elemento.Codigo_de_barras = codigo;
            elemento.Nombre = nombre;
            elemento.Proveedor = proveedor;
            elemento.Precio_de_Compra = precio;
            elemento.Impuesto = impuesto;
            elemento.Descripcion = descripcion;
            elemento.Descuento = descuento;
            elemento.Sucursal = sucursal;
            // Valida si existe un elemento dentro de la tabla, debido a que si no genera un error si el
            // valor ya existe dentro de la tabla
            if (BD.Productos.Any(info => info.Codigo_de_barras == elemento.Codigo_de_barras))
            {
                return "Ya existe ese producto en la base de datos";
            }
            else
            {

                BD.Productos.Add(elemento);
                BD.SaveChanges();
                return "Producto añadido";
            }
        }
        [HttpDelete]
        public string Delete(int codigo)
        {
            
            if (BD.Productos.Any(info => info.Codigo_de_barras == codigo))
            {

                var wc = BD.Productos.First(p => p.Codigo_de_barras == codigo);
                BD.Productos.Remove(wc);
                BD.SaveChanges();
                return "Producto eliminado";
            }
            else
            {
                return "Ese producto no existe";
            }
        }

        [HttpPut]
        public string Put(int codigo, string nombre, string proveedor, int precio, bool impuesto, bool descuento, string sucursal, string descripcion, int actual)
        {
            Productos elemento = new Productos();
            elemento.Codigo_de_barras = codigo;
            elemento.Nombre = nombre;
            elemento.Proveedor = proveedor;
            elemento.Precio_de_Compra = precio;
            elemento.Impuesto = impuesto;
            elemento.Descripcion = descripcion;
            elemento.Descuento = descuento;
            elemento.Sucursal = sucursal;
            if (BD.Productos.Any(info => info.Codigo_de_barras == actual))
            {

                var wc = BD.Productos.First(p => p.Codigo_de_barras == actual);
                BD.Productos.Remove(wc);
                BD.SaveChanges();
                if (BD.Productos.Any(info => info.Codigo_de_barras == elemento.Codigo_de_barras))
                {
                    return "Ya existe ese producto en la base de datos";
                }
                else
                {
                    BD.Productos.Add(elemento);
                    BD.SaveChanges();
                    return "Producto modificado";
                }

            }
            else
            {
                return "Ese producto no existe";
            }
        }
    }
}
