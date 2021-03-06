﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public DeleteModel(Bodea_Denis.Data.Bodea_DenisContext context)
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

            Masina = await _context.Masina.FirstOrDefaultAsync(m => m.ID == id);

            if (Masina == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Masina = await _context.Masina.FindAsync(id);

            if (Masina != null)
            {
                _context.Masina.Remove(Masina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
