using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentNotes.Models
{
    public class Note
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public byte ProgressRating { get; set; }

        public string ExtraNote { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }
        
    }
}