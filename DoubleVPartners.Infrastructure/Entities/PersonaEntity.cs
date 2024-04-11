using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Infrastructure.Entities
{
    public class PersonaEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2)]
        public int IdTipoIdentificacion { get; set; }
        [ForeignKey("IdTipoIdentificacion")]
        public TipoIdentificacionEntity tipoIdentificacion { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Identificacion")]
        [Column(Order = 3)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombres")]
        [Column(Order = 4)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Apellidos")]
        [Column(Order = 5)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Email")]
        [Column(Order = 6)]
        public string Email { get; set; }

        [Required]
        [Column(Order = 7)]
        public DateTime FechaCreacion { get; set; }
    }
}
