using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner.Models
{

    public class Bulletin
    {
        public int ID { get; set; }

        [Display(Name = "Meeting Conductor")]
        public string MeetingConductor { get; set; }

        [Display(Name = "Opening Hymn Number")]
        [Range(1, 341)]
        public int OpeningSongNumber { get; set; }

        [Display(Name = "Invocation Given By:")]
        public string OpeningPrayerName { get; set; }

        [Display(Name = "Sacrament Hymn Number")]
        [Range(1, 341)]
        public int SacramentSongNumber { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

        [Display(Name = "Closing Hymn Number")]
        [Range(1, 341)]
        public int ClosingSongNumber { get; set; }

        [Display(Name = "Benediction Given By:")]
        public string ClosingPrayerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }
    }
}