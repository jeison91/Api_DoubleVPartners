using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.DTO.Request
{
    public class UsuarioRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Usuario { get; set; }
        public string Pass { get; set; }
    }
}
