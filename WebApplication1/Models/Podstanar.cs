using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Podstanar
    {
        [Key]
        [Required]
        public int PodstanarID { get; set; }

        [Required]
        [StringLength(10)]
        public string Ime { get; set; }

        [Required]
        [StringLength(15)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(13)]
        public string JMBG { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Broj telefona")]
        public string BrojTelefona { get; set; }

        public virtual ICollection<Iznajmljivanje> Iznajmljivanje { get; set; }
    }
}