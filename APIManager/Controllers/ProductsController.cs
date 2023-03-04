using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQA.Application.ViewModels;
using WebsiteData.Data.Context;
using WebsiteData.Entities;

namespace APIManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebsiteDbContext _context;

        public ProductsController(WebsiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            var a = from pd in _context.Products
                    join ct in _context.Categories on pd.Category_Id equals ct.Category_Id
                    select new ProductViewModel
                    {
                        Product_Id = pd.Product_Id,
                        Product_Name = pd.Product_Name,
                        Product_Style = pd.Product_Style,
                        Product_Size = pd.Product_Size,
                        Product_Image = pd.Product_Image,
                        Product_Show = pd.Product_Show,
                        Product_Price = pd.Product_Price,
                        Product_Quantity = pd.Product_Quantity,
                        Product_Note = pd.Product_Note,
                        Category_Id = ct.Category_Id,
                        Category_Name = ct.Category_Name,
                    };
            return await a.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Product_Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                var rs = await _context.SaveChangesAsync();
                return Ok(rs);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            var rs = await _context.SaveChangesAsync();
            return Ok(rs);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            var rs = await _context.SaveChangesAsync();

            return Ok(rs);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }

        [HttpGet("FindByName")]
        public IActionResult GetProductByName(string Name)
        {
            var result = _context.Products.Where(m => m.Product_Name.Contains(Name));
            return Ok(result);
        }
    }
}
