using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentNotes.Models;

namespace StudentNotes.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] [Range(1, 10)] public byte ProgressRating { get; set; }

        public string ExtraNote { get; set; }

        public DateTime DateAdded { get; set; }

        public int StudentId { get; set; }
    }

}