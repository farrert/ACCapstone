using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OOPCapstone.Data;
using OOPCapstone.Models;

namespace OOPCapstone.Pages.TaskTracker
{
    public class DetailsModel : PageModel
    {
        private readonly OOPCapstone.Data.OOPCapstoneContext _context;

        public DetailsModel(OOPCapstone.Data.OOPCapstoneContext context)
        {
            _context = context;
        }

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
    }
}
