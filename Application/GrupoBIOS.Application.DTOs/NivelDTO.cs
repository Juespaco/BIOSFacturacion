using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{

    public class NivelDTO
    {
        public int? IDNivel { get; set; }

        [Required(ErrorMessage = "El campo NivelCentroOperativo es requerido")]
        public int NivelCentroOperativo { get; set; }

        [Required(ErrorMessage = "El campo NivelNombre es requerido")]
        [StringLength(510, ErrorMessage = "El campo NivelNombre no debe exceder los 510 caracteres")]
        public string NivelNombre { get; set; }

        [Required(ErrorMessage = "El campo NivelDiasGracia es requerido")]
        public int NivelDiasGracia { get; set; }

        [Required(ErrorMessage = "El campo NivelDiasCobertura es requerido")]
        public int NivelDiasCobertura { get; set; }

        [Required(ErrorMessage = "El campo NivelPosicion es requerido")]
        public double NivelPosicion { get; set; }

        [Required(ErrorMessage = "El campo NivelPrimerCobro es requerido")]
        public int NivelPrimerCobro { get; set; }

        [Required(ErrorMessage = "El campo NivelSegundoCobro es requerido")]
        public int NivelSegundoCobro { get; set; }
    }

}
