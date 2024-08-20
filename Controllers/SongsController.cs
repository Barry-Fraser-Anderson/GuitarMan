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

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            List<Song> songs;

            songs = sortOrder switch
            {
                "Title" => _dbContext.Songs.OrderBy(s => s.Title).ToList(),
                _ => _dbContext.Songs.OrderBy(s => s.Artist).ToList()
            };
            return View(songs);
        }

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var song = _dbContext.Songs.FirstOrDefault(song => song.Id == id);
            if (song is not null)
            {
                _dbContext.Songs.Remove(song);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var song = _dbContext.Songs.FirstOrDefault(song => song.Id == id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            _dbContext.Songs.Update(song);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

