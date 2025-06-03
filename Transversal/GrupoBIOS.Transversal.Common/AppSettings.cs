using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Transversal.Common
{
    public class AppSettings
    {
        public string? OriginCors { get; set; }
        public string? Secret { get; set; }
        public string? IsSuer { get; set; }
        public string? Audience { get; set; }
        public string? KeyBase { get; set; }
        public string? Expires { get; set; }
    }
}
