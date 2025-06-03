using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Transversal.Common
{
    public class ResponseSiesa<T>
    {
        public DetalleContainer<T>? detalle { get; set; }
        public int? codigo { get; set; }
        public string? mensaje { get; set; }        
    }

    public class DetalleContainer<T>
    {
        public T? Table { get; set; }
    }

}
