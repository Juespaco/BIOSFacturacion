using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.DTOs.Enum
{
    public enum EnumMessageTypeSnackBar
    {
        [Description("Operación exitosa")]
        Success = 1,
        [Description("Información relevante")]
        Info = 2,
        [Description("Advertencia importante")]
        Warning = 3,
        [Description("Error crítico")]
        Error = 4
    }
}
