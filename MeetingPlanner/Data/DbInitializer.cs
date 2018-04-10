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
            /*
                     var bulletins = new Bulletin[]
                        {
                        new Bulletin{MeetingConductor="Bishop",OpeningSongNumber=300,OpeningPrayerName="Brother Hill",ClosingSongNumber=152,ClosingPrayerName="Sister Hill",MeetingDate=DateTime.Parse("2018-04-08")},
                        new Bulletin{MeetingConductor="First Counceler",OpeningSongNumber=46,OpeningPrayerName="Sister Baker",ClosingSongNumber=12,ClosingPrayerName="Brother Lynn",MeetingDate=DateTime.Parse("2018-04-15")},
                        new Bulletin{MeetingConductor="Second Counceler",OpeningSongNumber=204,OpeningPrayerName="Brother Allen",ClosingSongNumber=97,ClosingPrayerName="Brother Davidson",MeetingDate=DateTime.Parse("2018-04-22")}
                        };

                        foreach (Bulletin b in bulletins)
                        {
                            context.Bulletins.Add(b);
                        }
                        context.SaveChanges();
                        */

            var speakers = new Speaker[]
            {
            new Speaker{BulletinID=0,Name="Sister Bradshaw",Topic="Prayer"},
            new Speaker{BulletinID=0,Name="Sister Smith",Topic="Tithing"},
            new Speaker{BulletinID=0,Name="Brother Calloway",Topic="Miracles"}
            };
            foreach (Speaker s in speakers)
            {
                context.Speakers.Add(s);
            }
            context.SaveChanges();
        }
    }
}