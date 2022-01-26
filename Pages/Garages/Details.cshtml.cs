using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Auto.Data;
using Auto.Models;

namespace Auto.Pages.Garages
{
    public class DetailsModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public DetailsModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

        public Garage Garage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Garage = await _context.Service.FirstOrDefaultAsync(m => m.ID == id);

            if (Garage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
