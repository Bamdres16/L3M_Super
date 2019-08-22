using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3MSuper.Class
{
    public partial class ListaProductos
    {
        public IEnumerable<string> Nombre { get; set; }
        public IEnumerable<int> Precio { get; set; }
        public int Total { get; set; }
    }
}