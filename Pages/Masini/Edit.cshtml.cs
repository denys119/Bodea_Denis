using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Masini
{
    public class EditModel : MasinaDotariPageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public EditModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Masina = await _context.Masina
                .Include(b => b.Angajat)
                .Include(b => b.MasinaDotari).ThenInclude(b => b.Dotare)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Masina == null)
            {
                return NotFound();
            }

            PopulateAssignedDotareData(_context, Masina);

            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDotari)
        {
            if (id == null) {
                return NotFound();
            }
            var masinaToUpdate = await _context.Masina.Include(i => i.Angajat).Include(i => i.MasinaDotari).ThenInclude(i => i.Dotare).FirstOrDefaultAsync(s => s.ID == id);
            if (masinaToUpdate == null) {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Masina>(masinaToUpdate, "Masina", i => i.Marca, i => i.Model, i => i.Culoare, i => i.An, i => i.Tara, i => i.Motor, i => i.DataAdaugare, i => i.Angajat)) {
                UpdateMasinaDotari(_context, selectedDotari, masinaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateMasinaDotari(_context, selectedDotari, masinaToUpdate);
            PopulateAssignedDotareData(_context, masinaToUpdate);
            return Page();
        }
    }
}
