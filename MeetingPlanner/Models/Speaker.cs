using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }

        [Display(Name = "Meeting ID")]
        public int BulletinID { get; set; }

        [Display(Name = "Speaker Name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Display(Name = "Topic")]
        [StringLength(50, ErrorMessage = "Topic cannot be longer than 50 characters.")]
        public string Topic { get; set; }

        public Bulletin Bulletin { get; set; }
    }
}
