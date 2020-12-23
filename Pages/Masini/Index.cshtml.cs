using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Masini
{
    public class IndexModel : PageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public IndexModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        public IList<Masina> Masina { get; set; }
        public MasinaData MasinaD { get; set; }
        public int MasinaID {get; set;}
        public int DotareID { get; set; }



        public async Task OnGetAsync(int? id, int? dotareID)
        {
            MasinaD = new MasinaData();
            MasinaD.Masini = await _context.Masina
                .Include(b => b.Angajat)
                .Include(b => b.MasinaDotari)
                .ThenInclude(b => b.Dotare)
                .AsNoTracking()
                .OrderBy(b => b.Marca)
                .ToListAsync();

            if(id != null)
            {
                MasinaID = id.Value;
                Masina masina = MasinaD.Masini
                    .Where(i => i.ID == id.Value).Single();
                MasinaD.Dotari = masina.MasinaDotari.Select(s => s.Dotare);
            }
        }
    }
}
