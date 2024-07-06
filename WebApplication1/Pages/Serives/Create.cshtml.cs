﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Pages.Serives
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Models.PRN221_TrialContext _context;

        public CreateModel(WebApplication1.Models.PRN221_TrialContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id");
        ViewData["RoomTitle"] = new SelectList(_context.Rooms, "Title", "Title");
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Services == null || Service == null)
            {
                return Page();
            }

            _context.Services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
