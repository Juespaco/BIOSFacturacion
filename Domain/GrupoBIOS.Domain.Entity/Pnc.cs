using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Entity
{
    public class Pnc
    {
        public int? IDPnc { get; set; }
        public int CoPnc { get; set; }
        public string NombrePnc { get; set; } = null!;
        public string CodigoPnc { get; set; } = null!;
        public int TarifaPnc { get; set; }
        public double FleteidaPnc { get; set; }
        public double FleteregPnc { get; set; }
    }
}
