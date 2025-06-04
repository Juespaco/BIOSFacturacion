using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{

    public class PncDTO
    {
        [Range(0, 9999, ErrorMessage = "El campo TarifaPnc no debe tener más de 4 dígitos")]
        public int? IDPnc { get; set; }

        [Required(ErrorMessage = "El campo CoPnc es requerido")]
        [Range(0, 9999, ErrorMessage = "El campo TarifaPnc no debe tener más de 4 dígitos")]
        public int CoPnc { get; set; }

        [Required(ErrorMessage = "El campo NombrePnc es requerido")]
        [StringLength(200, ErrorMessage = "El campo NombrePnc no debe exceder los 200 caracteres")]
        public string NombrePnc { get; set; }

        [Required(ErrorMessage = "El campo CodigoPnc es requerido")]
        [StringLength(4, ErrorMessage = "El campo CodigoPnc no debe exceder los 4 caracteres")]

        public string CodigoPnc { get; set; }

        [Required(ErrorMessage = "El campo TarifaPnc es requerido")]
        [Range(0, 9999, ErrorMessage = "El campo TarifaPnc no debe tener más de 4 dígitos")]
        public int TarifaPnc { get; set; }

        [Required(ErrorMessage = "El campo FleteidaPnc es requerido")]
        public double FleteidaPnc { get; set; }

        [Required(ErrorMessage = "El campo FleteregPnc es requerido")]
        public double FleteregPnc { get; set; }
    }

}
