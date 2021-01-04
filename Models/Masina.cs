using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bodea_Denis.Models
{
    public class Masina
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Marca Masina")]

        public string Marca { get; set; }

        [Required, StringLength(150, MinimumLength = 1)]
        [Display(Name = "Model Masina")]
        public string Model { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Culoare Masina")]
        public string Culoare { get; set; }

        [Range(1900, 3000)]
        [Display(Name = "An Fabricatie")]
        public string An { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Tara Provenienta")]
        public string Tara { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Motor Masina")]
        public string Motor { get; set; }

        [Display(Name = "Data Adaugarii")]
        [DataType(DataType.Date)]
        public DateTime DataAdaugare { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }

        [Display(Name = "Dotari Masina")]
        public ICollection<MasinaDotare> MasinaDotari { get; set; }

    }
}
