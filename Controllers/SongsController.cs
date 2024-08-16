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
    }
}
