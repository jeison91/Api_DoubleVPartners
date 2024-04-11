using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.DTO.Response
{
    public class PersonaResponseDTO
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
