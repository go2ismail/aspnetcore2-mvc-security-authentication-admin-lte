using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using motekarteknologi.Models;

namespace motekarteknologi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for SendGrid
            if (context.SendGrid.Any())
            {
                return;   // DB has been seeded
            }

            //initialize with empty SendGridUser and SendGridKey
            SendGrid sendGrid = new SendGrid();
            context.SendGrid.Add(sendGrid);
            context.SaveChanges();

        }

    }
}
