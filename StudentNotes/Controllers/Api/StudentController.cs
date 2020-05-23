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



        // GET   /api/student
        public IEnumerable<StudentDto> GetStudents()
        {
            return _context.Students.ToList().Select(Mapper.Map<Student, StudentDto>);
        }


        // GET   /api/student/id
        public StudentDto GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return  Mapper.Map<Student, StudentDto>(student);


        }

        // POST    /api/student
        [HttpPost]
        public StudentDto CreateStudent(StudentDto studentDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return studentDto;

        }


        // PUT     /api/student/id
        [HttpPut]
        public void UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<StudentDto, Student>(studentDto, studentInDb);
            

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


