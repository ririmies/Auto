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
    public class IndexModel : PageModel
    {
        private readonly Auto.Data.AutoContext _context;

        public IndexModel(Auto.Data.AutoContext context)
        {
            _context = context;
        }

        public IList<Garage> Garage { get;set; }

        public async Task OnGetAsync()
        {
            Garage = await _context.Service.ToListAsync();
        }
    }
}
