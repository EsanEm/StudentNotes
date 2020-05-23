using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNotes.Models;

namespace StudentNotes.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var student = _context.Students.ToList();


            return View(student);
        }



        public ActionResult Details(int id)
        {
            var student = _context.Students
                .Include(s => s.Notes)
                .SingleOrDefault(s => s.Id == id);

            if (student == null)
                return HttpNotFound();

            return View(student);
        }







        public ActionResult New()
        {

            return View("New");
        }
         




        public ActionResult Delete(int studentId)
        {
            var studentInDb = _context.Students.Single(n => n.Id == studentId);
            var studentNotesInDb = _context.Notes.ToList().Where(n => n.StudentId == studentInDb.Id);

            foreach (var note in studentNotesInDb)
            {
                _context.Notes.Remove(note);
            }



            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }





        public ActionResult Save(Student student)
        {

            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }

            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.Name = student.Name;
                studentInDb.Address = student.Address;
                studentInDb.Phone = student.Phone;
               
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");



        }

        public ActionResult Edit(int studentId)
        {
            var studentInDb = _context.Students.Single(n => n.Id == studentId);
            
            return View(studentInDb);
        }
    }
}