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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryContext _context;

        public CategoryController(CategoryContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            return _context.Categories.ToList();
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/categories
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            
         //   return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
