using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner.Models
{

    public class Bulletin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int ID { get; set; }
        public string MeetingConductor { get; set; }
        public int OpeningSongNumber { get; set; }
        public string OpeningPrayerName { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
        public int ClosingSongNumber { get; set; }
        public string ClosingPrayerName { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}