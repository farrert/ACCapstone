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
    public class IndexModel : PageModel
    {
        private readonly OOPCapstone.Data.OOPCapstoneContext _context;

        public IndexModel(OOPCapstone.Data.OOPCapstoneContext context)
        {
            _context = context;
        }

        public IList<Tasks> Tasks { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string CompleteSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            CompleteSort = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            var tasks = from r in _context.Tasks
                        select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(r => r.Name.Contains(SearchString));
            }
            if (sortOrder=="desc")
            {
                tasks = tasks.OrderByDescending(r => r.TaskStateValue);
            }
            else
                tasks = tasks.OrderBy(r => r.TaskStateValue);
            Tasks = await tasks.ToListAsync();
        }  
    }
}
