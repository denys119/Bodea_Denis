using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bodea_Denis.Models
{
    public class Dotare
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nume Dotare")]
        public string DotareNume { get; set; }

        
        public ICollection<MasinaDotare> MasinaDotari { get; set; }
    }
}
