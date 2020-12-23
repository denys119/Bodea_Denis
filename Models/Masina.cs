using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodea_Denis.Models
{
    public class Masina
    {
        public int ID { get; set; }
        public string Marca { get; set; }

        public string Model { get; set; }

        public string Culoare { get; set; }

        public string An { get; set; }

        public string Tara { get; set; }
        public string Motor { get; set; }

        public DateTime DataAdaugare { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        public ICollection<MasinaDotare> MasinaDotari { get; set; }

    }
}
