using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodea_Denis.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string NumeAngajat { get; set; }
        public ICollection<Masina> Masini { get; set; }

    }
}
