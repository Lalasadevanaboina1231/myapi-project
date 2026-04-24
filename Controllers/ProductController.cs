using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapiproject.Data;
using myapiproject.Models;
 
namespace myapiproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
 
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        //GET ALL
        [HttpGet]
public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
{
    return Ok(await _context.Products.ToListAsync());
}
//GET BY ID
[HttpGet("{id}")]
public async Task<ActionResult<Product>> GetProduct(int id)
{
    var product = await _context.Products.FindAsync(id);
 
    if (product == null)
    {
        return NotFound();
    }
 
    return Ok(product);
}
//ADD POST
 [HttpPost]
public async Task<ActionResult<Product>> CreateProduct(Product product)
{
    _context.Products.Add(product);
    await _context.SaveChangesAsync();
 
    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
}
//ADD PUT
[HttpPut("{id}")]
public async Task<IActionResult> UpdateProduct(int id, Product product)
{
    if (id != product.Id)
    {
        return BadRequest();
    }
 
    _context.Entry(product).State = EntityState.Modified;
    await _context.SaveChangesAsync();
 
    return NoContent();
}
//ADD Delete
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteProduct(int id)
{
    var product = await _context.Products.FindAsync(id);
 
    if (product == null)
    {
        return NotFound();
    }
 
    _context.Products.Remove(product);
    await _context.SaveChangesAsync();
 
    return NoContent();
}
 
 
        //api/product
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
 
        // GET:api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
 
            if (product == null)
                return NotFound();
 
            return Ok(product);
        }
 
        //  POST: api/product
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
 
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
 
        //  PUT: api/product/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();
 
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
 
        //  DELETE: api/product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
 
            if (product == null)
                return NotFound();
 
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
    }
}
 