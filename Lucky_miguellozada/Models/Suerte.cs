using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_miguellozada.Models
{
    public class Suerte
    {

        [Key]
        [Display(Name = "Numero de la suerte")]
        public int SuerteId { get; set; }
        [Required]

        [Display(Name = "Detalle de que te depara de suerte")]
        public string Detalle { get; set; }

        [Url]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

    }
}
