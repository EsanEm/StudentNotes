using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentNotes.Models
{
    public class Note
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Progress Rating")]
        public byte ProgressRating { get; set; }

        [Display(Name = "Extra Note")]
        public string ExtraNote { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } 
        
        public Student Student { get; set; }

        public int StudentId { get; set; }
        
    }
}