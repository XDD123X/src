using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PE1.Models;

namespace PE1.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly PE1.Models.PRN221_TrialContext _context;

        public IndexModel(PE1.Models.PRN221_TrialContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Services != null)
            {
                Service = await _context.Services
                .Include(s => s.EmployeeNavigation)
                .Include(s => s.RoomTitleNavigation).ToListAsync();
            }
        }
    }
}
