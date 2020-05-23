using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using StudentNotes.Dtos;
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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET   /api/student
        public IHttpActionResult GetStudents()
        {
            var studentDto = _context.Students.ToList().Select(Mapper.Map<Student, StudentDto>);

            return Ok(studentDto);
        }


        // GET   /api/student/id
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(Mapper.Map<Student, StudentDto>(student));


        }

        // POST    /api/student
        [HttpPost]
        public IHttpActionResult CreateStudent(StudentDto studentDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);

        }


        // PUT     /api/student/id
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                return NotFound();

            Mapper.Map<StudentDto, Student>(studentDto, studentInDb);
            

            _context.SaveChanges();

            return Ok();
        }


        // DELETE     /api/student/id
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                return NotFound();

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}


