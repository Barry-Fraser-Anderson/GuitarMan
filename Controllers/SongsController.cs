using GuitarMan.Data;
using GuitarMan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Index(string sortOrder)
        {
        //    List<Song> songs;

            var songs = sortOrder switch
            {
                "Title" => await _dbContext.Songs.OrderBy(s => s.Title).ToListAsync(),
                _ => await _dbContext.Songs.OrderBy(s => s.Artist).ToListAsync()
            };
            return View(songs);
        }

        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public async Task<ActionResult> Create(Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var song = await _dbContext.Songs.FirstOrDefaultAsync(song => song.Id == id);
            if (song is not null)
            {
                _dbContext.Songs.Remove(song);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var song = await _dbContext.Songs.FirstOrDefaultAsync(song => song.Id == id);
            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(Song song)
        {
            _dbContext.Songs.Update(song);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

