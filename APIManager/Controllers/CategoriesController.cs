using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteData.Data.Context;
using WebsiteData.Entities;

namespace APIManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly WebsiteDbContext _context;

        public CategoriesController(WebsiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            //var a = from ct in _context.Categories
            //        select new Category
            //        {
            //            Category_Id = ct.Category_Id,
            //            Category_Name = ct.Category_Name,
            //            //Category_Quantity = .Sum(x => x.Product_Quantity)
            //        };
            //return await a.ToListAsync();
            var categoties = _context.Categories.ToList();
            foreach(var category in categoties)
            {
                var products = _context.Products.Where(x => x.Category_Id == category.Category_Id).ToList();
                category.Category_Quantity = products.Sum(x => x.Product_Quantity);
            }
            return categoties.ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpGet("FindByName")]
        public IActionResult GetCategoryByName(string Name)
        {
            var result = _context.Categories.Where(m => m.Category_Name.Contains(Name));
            return Ok(result);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Category_Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                var rs = await _context.SaveChangesAsync();
                return Ok(rs);
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
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            var rs = await _context.SaveChangesAsync();
            return Ok(rs);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            var rs = await _context.SaveChangesAsync();

            return Ok(rs);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Category_Id == id);
        }
    }
}
