﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auto.Data;
using Auto.Models;

namespace Auto.Pages.Parts
{
    public class EditModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public EditModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Part = await _context.Piesa
                .Include(p => p.Programare).FirstOrDefaultAsync(m => m.ID == id);

            if (Part == null)
            {
                return NotFound();
            }
           ViewData["AppointmentID"] = new SelectList(_context.Programare, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(Part.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartExists(int id)
        {
            return _context.Piesa.Any(e => e.ID == id);
        }
    }
}
