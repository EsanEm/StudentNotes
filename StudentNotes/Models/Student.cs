using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentNotes.Models
{
    public class Student
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public List<Note> Notes { get; set; }
    }
}