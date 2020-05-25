using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }


        // GET   /api/note/id
        public Note GetNote(int id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);

            if (note == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return note;
        }

        // POST    /api/student
        [HttpPost]
        public Note CreateNote(Note note)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Notes.Add(note);
            _context.SaveChanges();

            return note;
        }


        // PUT     /api/student/id
        [HttpPut]
        public void UpdateNote(int id, Note note)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var noteInDb = _context.Notes.Single(n => n.Id == id);

            if (noteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            noteInDb.Name = note.Name;
            noteInDb.ProgressRating = note.ProgressRating;
            noteInDb.ExtraNote = note.ExtraNote;
            noteInDb.DateAdded = note.DateAdded;
            noteInDb.StudentId = note.StudentId;

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