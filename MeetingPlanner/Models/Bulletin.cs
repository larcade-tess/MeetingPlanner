using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPlanner.Models
{

    public class Bulletin
    {
        [Display(Name = "Meeting ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Meeting Conductor")]
        [StringLength(50, ErrorMessage = "Meeting Conductor cannot be longer than 50 characters.")]
        public string MeetingConductor { get; set; }

        [Required]
        [Display(Name = "Opening Hymn Number")]
        [Range(1, 341)]
        public int OpeningSongNumber { get; set; }

        [Required]
        [Display(Name = "Invocation Given By")]
        [StringLength(50, ErrorMessage = "Invocation cannot be longer than 50 characters.")]
        public string OpeningPrayerName { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        [Range(1, 341)]
        public int SacramentSongNumber { get; set; }


        [Display(Name = "Intermediate Hymn")]
        [DisplayFormat(NullDisplayText = "No Intermediate Hymn")]
        [Range(1, 341)]
        public int? IntermediateSongNumber { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        [Range(1, 341)]
        public int ClosingSongNumber { get; set; }

        [Required]
        [Display(Name = "Benediction Given By")]
        [StringLength(50, ErrorMessage = "Benediction cannot be longer than 50 characters.")]
        public string ClosingPrayerName { get; set; }

        [Required]
        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }
    }
}