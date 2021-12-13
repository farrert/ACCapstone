using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOPCapstone.Models;

namespace OOPCapstone.Data
{
    public class OOPCapstoneContext : DbContext
    {
        public OOPCapstoneContext (DbContextOptions<OOPCapstoneContext> options)
            : base(options)
        {
        }

        public DbSet<OOPCapstone.Models.Tasks> Tasks { get; set; }
    }
}
