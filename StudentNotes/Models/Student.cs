using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentNotes.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string Phone { get; set; }

        public List<Note> Notes { get; set; }
    }
}