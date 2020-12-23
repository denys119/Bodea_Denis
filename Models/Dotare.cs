using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodea_Denis.Models
{
    public class Dotare
    {
        public int ID { get; set; }
        public string DotareNume { get; set; }

        public ICollection<MasinaDotare> MasinaDotari { get; set; }
    }
}
