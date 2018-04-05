using MeetingPlanner.Data;
using MeetingPlanner.Models;
using System;
using System.Linq;

namespace MeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Meetings.
            if (context.Bulletins.Any())
            {
                return;   // DB has been seeded
            }

            var bulletins = new Bulletin[]
            {
            new Bulletin{MeetingConductor="Bishop",MeetingDate=DateTime.Parse("2018-04-08")},
            new Bulletin{MeetingConductor="First Counceler",MeetingDate=DateTime.Parse("2018-04-15")},
            new Bulletin{MeetingConductor="Second Counceler",MeetingDate=DateTime.Parse("2018-04-22")}
            };
            foreach (Bulletin b in bulletins)
            {
                context.Bulletins.Add(b);
            }
            context.SaveChanges();
        }
    }
}