using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBIOS.Domain.Entity
{

    namespace TuProyecto.Domain.Entities
    {
        public class Nivel
        {
            public int IDNivel { get; set; }
            public int NivelCentroOperativo { get; set; }
            public string NivelNombre { get; set; } = null!;
            public int NivelDiasGracia { get; set; }
            public int NivelDiasCobertura { get; set; }
            public double NivelPosicion { get; set; }
            public int NivelPrimerCobro { get; set; }
            public int NivelSegundoCobro { get; set; }
            public int NivelPNCCobro { get; set; }
        }
    }

}
