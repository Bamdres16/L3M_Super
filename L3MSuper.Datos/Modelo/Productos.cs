//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace L3MSuper.Datos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        public int Codigo_de_barras { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }
        public int Precio_de_Compra { get; set; }
        public bool Impuesto { get; set; }
        public bool Descuento { get; set; }
        public string Sucursal { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
        public virtual Sucursales Sucursales { get; set; }
    }
}
