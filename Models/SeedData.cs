using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OOPCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPCapstone.Models
{
     public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OOPCapstoneContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OOPCapstoneContext>>()))
            {
                // Look for any movies.
                if (context.Tasks.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tasks.AddRange(
                     new Tasks
                     {
                         Name = "Message Bottle",
                         Quantity = 2,
                         Notes = "Do not forget the boat tour bottle",
                         Description = "Everyday there are two message bottles that you can pick up off the beach.  The first one will be on your island and the second can be found when you speak with Kappn and visit a different island.",
                         TaskStateValue = 0
                     },
                   new Tasks
                   {
                       Name = "Mailbox",
                       Notes = "Make sure that you have room in your inventory",
                       Description = "As the name implies, you should check you mailbox daily, not crucial but it will help you stay up to date with the current events on the island.",
                       TaskStateValue = 0
                   },
                   new Tasks
                   {
                       Name = "Coffee Break",
                       Notes = "The latest gift was a recipe for Sable Cookies",
                       Description = "The Roost is a new feature in the game, so visiting the coffee shop in the museum daily seems like a good idea.  I do not even know if more DIYs are available, but the coffee seems to be amazing.",
                       TaskStateValue = 0
                   },
                   new Tasks
                   {
                       Name = "Boat Tour",
                       Notes = "Visit Katrina for good luck",
                       Description = "If you speak with Kapp'n on the docks, he will be able to take you to an island that is in a different season, thus allowing you to get many different DIYs, ingredients, and money",
                       TaskStateValue = 0
                   },
                   new Tasks
                   {
                       Name = "Shooting Stars",
                       Notes = "Stars were wished on 12/4",
                       Description = "Star fragments can be found on the beach the evening after you with upon them.  They will only be available the next day and if you log out during the evening all of the star fragments will disappear.",
                       TaskStateValue = 0
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
