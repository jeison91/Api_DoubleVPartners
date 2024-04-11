using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.DTO.Request
{
    public class PersonaRequestDTO
    {
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Display(Name = "Tipo de Identificacion")]
        public int IdTipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La {0} es un campo obligatorio.")]
        [StringLength(20, ErrorMessage = "La {0} no puede exceder los {1} caracteres.")]
        [Display(Name = "Identificacion")]
        [CustomValidation(typeof(DocumentValidation), "ValidateDocumento")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Los {0} es obligatorio.")]
        [Display(Name = "Nombres")]
        [StringLength(50, ErrorMessage = "Los {0} excede la cantidad de caracteres permitidos.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los {0} es obligatorio.")]
        [Display(Name = "Apellidos")]
        [StringLength(50, ErrorMessage = "Los {0} excede la cantidad de caracteres permitidos.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "El {0} no tiene la estructura correcta.")]
        public string Email { get; set; }
    }

    public class DocumentValidation
    {
        public static ValidationResult? ValidateDocumento(string Document)
        {
            return !int.TryParse(Document, out _) ? new ValidationResult("La Identificación solo puede contener números.") : ValidationResult.Success;
        }
    }
}
