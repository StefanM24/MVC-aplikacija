using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


namespace WebApplication1.Models
{
    public class Stan
    {
        [Key]
        [Required]
        public int StanID { get; set; }

        [Required]
        public int Kvadratura { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresa { get; set; }

        [Required]
        public int Sprat { get; set; }

        [Required]
        [DisplayName("Cena(EUR)")]
        public int Cena { get; set; }

        [Required]
        [StringLength(20)]
        public string Vlasnik { get; set; }

        [Required]
        [StringLength(20)]
        public string Stanje { get; set; }

        [Required]
        [DisplayName("Uknjižen")]
        public bool Uknjizen { get; set; }

        [Required]
        [DisplayName("Namešten")]
        public bool Namesten { get; set; }

        [StringLength(50)]
        [DisplayName("Dodatna opremljenost")]
        public string DodatnaOpremljenost { get; set; }

        [Required]
        public int VrstaStanaID { get; set; }
        public virtual VrstaStana VrstaStana { get; set; }

        [Required]
        public int GradID { get; set; }
        public virtual Grad Grad { get; set; }

        public virtual ICollection<Iznajmljivanje> Iznajmljivanje { get; set; }
    }
}