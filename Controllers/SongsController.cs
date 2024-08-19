using GuitarMan.Data;
using GuitarMan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuitarMan.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SongsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Song> songs = _dbContext.Songs.ToList();
            return View(songs);
        }

        public IActionResult CreateEditForm()
        {
            return View();
        }
         
        public IActionResult Delete(int id)
        {
            var song = _dbContext.Songs.SingleOrDefault(song => song.Id == id);
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CreateEditOk(Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

