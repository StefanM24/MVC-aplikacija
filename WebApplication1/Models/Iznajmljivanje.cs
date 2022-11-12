using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Iznajmljivanje
    {
        [Key]
        [Required]
        public int IznajmljivanjeID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Datum početka")]
        public DateTime DatumPocetka { get; set; }

        [Required]
        public int StanID { get; set; }
        public virtual Stan Stan { get; set; }

        [Required]
        public int PodstanarID { get; set; }
        public virtual Podstanar Podstanar { get; set; }
    }
}