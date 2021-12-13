using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OOPCapstone.Data;
using OOPCapstone.Models;

namespace OOPCapstone.Pages.TaskTracker
{
    public class CreateModel : PageModel
    {
        private readonly OOPCapstone.Data.OOPCapstoneContext _context;

        public CreateModel(OOPCapstone.Data.OOPCapstoneContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tasks Tasks { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(Tasks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
