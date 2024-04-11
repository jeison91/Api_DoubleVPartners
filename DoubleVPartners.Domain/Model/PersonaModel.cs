using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoubleVPartners.Domain.Model
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string CalculoIdentificador => Identificacion.Trim() + " " + IdTipoIdentificacion;
        public string NombreCompleto => $"{Nombres.Trim()} {Apellidos.Trim()}";
        public TipoIdentificacionModel tipoIdentificacion { get; set; }
    }
}
