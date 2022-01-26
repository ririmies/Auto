using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Auto.Data;
using Auto.Models;

namespace Auto.Pages.Parts
{
    public class DetailsModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public DetailsModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
