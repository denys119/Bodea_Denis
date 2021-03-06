﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bodea_Denis.Data;
using Bodea_Denis.Models;

namespace Bodea_Denis.Pages.Dotari
{
    public class DeleteModel : PageModel
    {
        private readonly Bodea_Denis.Data.Bodea_DenisContext _context;

        public DeleteModel(Bodea_Denis.Data.Bodea_DenisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dotare Dotare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dotare = await _context.Dotare.FirstOrDefaultAsync(m => m.ID == id);

            if (Dotare == null)
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

            Dotare = await _context.Dotare.FindAsync(id);

            if (Dotare != null)
            {
                _context.Dotare.Remove(Dotare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
