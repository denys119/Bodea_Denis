using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Dotari
{
    public class CreateModel : PageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public CreateModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dotare Dotare { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dotare.Add(Dotare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
