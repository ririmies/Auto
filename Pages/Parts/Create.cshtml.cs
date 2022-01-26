using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Auto.Data;
using Auto.Models;

namespace Auto.Pages.Parts
{
    public class CreateModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public CreateModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AppointmentID"] = new SelectList(_context.Programare, "ID", "Date");
            return Page();
        }

        [BindProperty]
        public Part Part { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Piesa.Add(Part);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
