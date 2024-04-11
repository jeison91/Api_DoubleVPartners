using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.DTO.Response
{
    public class PersonaResponseDTO
    {
        public string TipoIdentificacion { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
