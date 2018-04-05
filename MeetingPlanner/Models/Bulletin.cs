using System;
using System.Collections.Generic;

namespace MeetingPlanner.Models
{

    public class Bulletin
    {
        public int ID { get; set; }
        public string MeetingConductor { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}