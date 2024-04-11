using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Infrastructure.Entities
{
    public class UsuarioEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Usuario")]
        [Column(Order = 2)]
        public string Usuario { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Pass")]
        [Column(Order = 3)]
        public string Pass { get; set; }

        [Required]
        [Display(Name = "FechaCreacion")]
        [Column(Order = 4)]
        public DateTime FechaCreacion { get; set; }
    }
}
