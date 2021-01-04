using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bodea_Denis.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele angajatului trebuie sa fie de forma Prenume Nume"), Required, StringLength(50, MinimumLength =3)]
        [Display(Name = "Nume Angajat")]
        public string NumeAngajat { get; set; }
        public ICollection<Masina> Masini { get; set; }

    }
}
