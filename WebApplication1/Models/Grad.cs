using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Grad
    {
        [Key]
        [Required]
        public int GradID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Grad")]
        public string NazivGrada { get; set; }

        [Required]
        [DisplayName("Poštanski broj")]
        public int PostanskiBroj { get; set; }

        public virtual ICollection<Stan> Stan { get; set; }
    }
}