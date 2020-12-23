using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodea_Denis.Models
{
    public class MasinaDotare
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }
        public Masina Masina { get; set; }
        public int DotareID { get; set; }
        public Dotare Dotare { get; set; }

    }
}
