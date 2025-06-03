using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrupoBIOS.Application.DTOs
{

    public class ExcepcionDTO
    {
        public int IdExcepcion { get; set; }

        [Required(ErrorMessage = "El ID de la compañía es requerido")]
        public int IdCompania { get; set; }

        [StringLength(255, ErrorMessage = "La planta no debe exceder los 255 caracteres")]
        [Required(ErrorMessage = "El campo planta es requerido")]
        public string Planta { get; set; }

        [StringLength(50, ErrorMessage = "El NIT no debe exceder los 50 caracteres")]
        [Required(ErrorMessage = "El campo nit es requerido")]
        public string Nit { get; set; }

        [StringLength(255, ErrorMessage = "El nombre del cliente no debe exceder los 255 caracteres")]
        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo 'CreadoPor' es requerido")]
        public string CreadoPor { get; set; }
    }


}
