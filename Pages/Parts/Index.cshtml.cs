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
    public class IndexModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public IndexModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

        public IList<Part> Part { get;set; }

        public async Task OnGetAsync()
        {
            Part = await _context.Piesa
                .Include(p => p.Programare).ToListAsync();
        }
    }
}
