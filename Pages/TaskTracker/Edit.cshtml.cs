using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOPCapstone.Data;
using OOPCapstone.Models;

namespace OOPCapstone.Pages.TaskTracker
{
    public class EditModel : PageModel
    {
        private readonly OOPCapstone.Data.OOPCapstoneContext _context;

        public EditModel(OOPCapstone.Data.OOPCapstoneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tasks Tasks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tasks = await _context.Tasks.FirstOrDefaultAsync(m => m.ID == id);

            if (Tasks == null)
            {
                return NotFound();
            }
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

            _context.Attach(Tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(Tasks.ID))
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

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.ID == id);
        }
    }
}
