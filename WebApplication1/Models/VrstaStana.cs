using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class VrstaStana
    {
        [Key]
        [Required]
        public int VrstaStanaID { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Vrsta")]
        public string NazivVrste { get; set; }

        public virtual ICollection<Stan> Stan { get; set; }
    }
}