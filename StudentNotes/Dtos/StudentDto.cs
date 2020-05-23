using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentNotes.Models;

namespace StudentNotes.Dtos
{
    public class StudentDto
    {


        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string Phone { get; set; }

        
    }
}