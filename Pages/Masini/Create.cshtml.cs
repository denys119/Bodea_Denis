using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Masini
{
    public class CreateModel : MasinaDotariPageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public CreateModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");
            var masina = new Masina();
            masina.MasinaDotari = new List<MasinaDotare>();
            PopulateAssignedDotareData(_context, masina);
            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedDotari)
        {
            var newMasina = new Masina();
            if(selectedDotari != null)
            {
                newMasina.MasinaDotari = new List<MasinaDotare>();
                foreach(var dot in selectedDotari)
                {
                    var dotToAdd = new MasinaDotare
                    {
                        DotareID = int.Parse(dot)
                    };
                    newMasina.MasinaDotari.Add(dotToAdd);
                }
            }
            if(await TryUpdateModelAsync<Masina>(
                newMasina,
                "Masina",
                i => i.Marca, i => i.Model, i => i.Culoare, i => i.An, i => i.Tara, i => i.Motor, i => i.DataAdaugare, i => i.AngajatID))
            {
                _context.Masina.Add(newMasina);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedDotareData(_context, newMasina);
            return Page();
           
        }
    }
}
