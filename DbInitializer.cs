using MeetingPlanner.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Meetings.
            if (context.Meetings.Any())
            {
                return;   // DB has been seeded
            }

            var meetings = new Meeting[]
            {
            new Meeting{MeetingConductor="Bishop",MeetingDate=DateTime.Parse("2018-04-08")},
            new Meeting{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2018-04-15")},
            new Meeting{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-04-22")}
            };
            foreach (Meeting m in meetings)
            {
                context.meetings.Add(m);
            }
            context.SaveChanges();
        }
    }
}