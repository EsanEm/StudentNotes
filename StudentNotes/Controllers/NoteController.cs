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
        // GET: Note
        //  public ActionResult Index()
        //  {
        //       return View();
        //  }

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
    }
}