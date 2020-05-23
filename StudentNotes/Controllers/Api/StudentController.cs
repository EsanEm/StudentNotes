using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using StudentNotes.Models;

namespace StudentNotes.Controllers.Api
{
    public class StudentController : ApiController
    {

        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }



        // GET   /api/student
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }


        // GET   /api/student/id
        public Student GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return student;


        }

        // POST    /api/student
        [HttpPost]
        public Student CreateStudent(Student student)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Students.Add(student);
            _context.SaveChanges();

            return student;

        }


        // PUT     /api/student/id
        [HttpPut]
        public void UpdateStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            studentInDb.Name = student.Name;
            studentInDb.Address = student.Address;
            studentInDb.Phone = student.Phone;

            _context.SaveChanges();

        }


        // DELETE     /api/student/id
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

        }
    }
}


