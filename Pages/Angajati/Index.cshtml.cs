using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public IndexModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }

        public async Task OnGetAsync()
        {
            Angajat = await _context.Angajat.ToListAsync();
        }
    }
}
