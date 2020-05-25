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
        public IEnumerable<NoteDto> GetNotes()
        {
            return _context.Notes.ToList().Select(Mapper.Map<Note, NoteDto>);
        }


        // GET   /api/note/id
        public NoteDto GetNote(int id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);

            if (note == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Note, NoteDto>(note);
        }

        // POST    /api/student
        [HttpPost]
        public NoteDto CreateNote(NoteDto noteDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var note = Mapper.Map<NoteDto, Note>(noteDto);
            _context.Notes.Add(note);
            _context.SaveChanges();

            noteDto.Id = note.Id;
            return noteDto;
        }


        // PUT     /api/student/id
        [HttpPut]
        public void UpdateNote(int id, NoteDto noteDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var noteInDb = _context.Notes.Single(n => n.Id == id);

            if (noteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<NoteDto, Note>(noteDto, noteInDb);
            
            _context.SaveChanges();
        }


        // DELETE     /api/student/id
        [HttpDelete]
        public void DeleteNote(int id)
        {
            var noteInDb = _context.Notes.SingleOrDefault(n => n.Id == id);

            if (noteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Notes.Remove(noteInDb);
            _context.SaveChanges();
        }
    }
}