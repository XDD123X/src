using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Serives
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.PRN221_TrialContext _context;

        public IndexModel(WebApplication1.Models.PRN221_TrialContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;
		[BindProperty(SupportsGet = true)]
		public string? SearchString { get; set; }

		public async Task OnGetAsync()
        {
            if (_context.Services != null)
            {
                Service = await _context.Services
                .Where(s => s.Month == 3)
                .Include(s => s.EmployeeNavigation)
                .Include(s => s.RoomTitleNavigation)
                .ToListAsync();
				if (!string.IsNullOrEmpty(SearchString))
				{
					Service = Service.Where(s => s.RoomTitle.Contains(SearchString)).ToList();
				}
			}
        }
    }
}
