using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using StudentNotes.Dtos;
using StudentNotes.Models;

namespace StudentNotes.Controllers.Api
{
    public class NoteController : ApiController
    {
        private ApplicationDbContext _context;

        public NoteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET   /api/Note
        public IHttpActionResult GetNotes()
        {
            var noteDto = _context.Notes.ToList().Select(Mapper.Map<Note, NoteDto>);
            return Ok(noteDto);
        }


        // GET   /api/note/id
        public IHttpActionResult GetNote(int id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);

            if (note == null)
                return NotFound();

            return Ok(Mapper.Map<Note, NoteDto>(note));
        }

        // POST    /api/student
        [HttpPost]
        public IHttpActionResult CreateNote(NoteDto noteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var note = Mapper.Map<NoteDto, Note>(noteDto);
            _context.Notes.Add(note);
            _context.SaveChanges();

            noteDto.Id = note.Id;
            return Created(new Uri(Request.RequestUri + "/" + note.Id), noteDto);
        }


        // PUT     /api/student/id
        [HttpPut]
        public IHttpActionResult UpdateNote(int id, NoteDto noteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var noteInDb = _context.Notes.Single(n => n.Id == id);

            if (noteInDb == null)
                return NotFound();

            Mapper.Map<NoteDto, Note>(noteDto, noteInDb);

            _context.SaveChanges();

            return Ok();
        }


        // DELETE     /api/student/id
        [HttpDelete]
        public IHttpActionResult DeleteNote(int id)
        {
            var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == id);

            if (noteInDb == null)
                return NotFound();

            _context.Notes.Remove(noteInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}