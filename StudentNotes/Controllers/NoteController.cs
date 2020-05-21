using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using StudentNotes.Models;

namespace StudentNotes.Controllers
{
    public class NoteController : Controller
    {
        

        private ApplicationDbContext _context;

        public NoteController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Details(int id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);

            return View(note);
            //   throw new NotImplementedException();
        }

        public ActionResult Save(Note note)
        {

            //note.StudentId = 2;

            if (note.Id == 0)
            {
                
                _context.Notes.Add(note);
            }

            else
            {
                var noteInDb = _context.Notes.Single(n => n.Id == note.Id);
                noteInDb.Name = note.Name;
                noteInDb.ProgressRating = note.ProgressRating;
                noteInDb.ExtraNote = note.ExtraNote;
                noteInDb.StudentId = note.StudentId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
           
        }

        public ActionResult New(int studentId)
        {

           
            return View("Details");
        }



        public void Delete(int id)
        {

            var noteInDb = _context.Notes.Single(n => n.Id == id);


            _context.Notes.Remove(noteInDb);
            _context.SaveChanges();
        }
    }
}