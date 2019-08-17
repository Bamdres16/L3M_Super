using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L3MSuper.Class
{
    public class Database<T>
    {
        public IEnumerable<T> results { get; set; }
    }
}