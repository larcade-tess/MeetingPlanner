using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        public int BulletinID { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }

        public Bulletin Bulletin { get; set; }
    }
}
