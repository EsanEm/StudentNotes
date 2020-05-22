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


        // GET: Student
        public ActionResult Index()
        {

            var student = _context.Students.ToList();


            return View(student);
        }

        public ActionResult Details(int id)
        {
            var student = _context.Students
                .Include(c => c.Notes)
                .SingleOrDefault(s => s.Id == id);

            if (student == null)
                return HttpNotFound();

            return View(student);
        }

        public ActionResult New()
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int studentid)
        {
            var studentInDb = _context.Students.Single(n => n.Id == studentid);

           // var noteInDbStudentId = noteInDb.StudentId;

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }
    }
}