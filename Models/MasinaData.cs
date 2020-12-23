using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodea_Denis.Models
{
    public class MasinaData
    {
        public IEnumerable<Masina> Masini { get; set; }

        public IEnumerable<Dotare> Dotari { get; set; }

        public IEnumerable<MasinaDotare> MasinaDotari { get; set; }
    }
}
