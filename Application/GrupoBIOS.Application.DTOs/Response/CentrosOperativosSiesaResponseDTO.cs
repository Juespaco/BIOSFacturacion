using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.DTOs.Response
{
    public class CentrosOperativosSiesaResponseDTO
    {
        public int f_cia { get; set; }
        public string f_co { get; set; } = string.Empty;
        public string? f_co1 { get; set; }
        public string? f_regional { get; set; }
        public int f_estado { get; set; }

    }
}
