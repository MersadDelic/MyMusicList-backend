using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicList.Models;

namespace MyMusicList.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongContext _context;

        public SongController(SongContext context)
        {
            _context = context;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        // GET: api/songs
        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetSongs()
        {
            return _context.Songs.ToList();
        }

        // GET: api/songs/5
        [HttpGet("{id}")]
        public ActionResult<Song> GetSong(int id)
        {
            var song = _context.Songs.Find(id);

            if (song == null)
            {
                return NotFound();
            }
            return song;
        }
        
        // GET: api/categories/5/songs
        [HttpGet("~/api/categories/{categoryId}/songs")]
        public ActionResult<List<Song>> GetSongs(int categoryId)
        {
            return _context.Songs.ToList().FindAll(x => x.CategoryId.Equals(categoryId));
        }

        // PUT: api/songs/5
        [HttpPut("{id}")]
        public IActionResult PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/songs
        [HttpPost]
        public ActionResult<Song> PostSong(Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();

            // return CreatedAtAction("GetSong", new { id = song.Id }, song);
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }

        // DELETE: api/songs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            var song = _context.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            _context.SaveChanges();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
