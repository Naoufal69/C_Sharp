using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace WebApplication1.Controllers{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            return await _context.products.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetById(int id)
        {
            List<Product> tmp_Products = new List<Product>();
            if (_context.products == null)
            {
                return NotFound();
            }
            int i = 0;
            foreach (Product produit in _context.products)
            {
                if (produit.Id == id)
                {
                    tmp_Products.Add(produit);
                }
                i++;
            }
            return tmp_Products;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName(string name)
        {
            List<Product> tmp_Products = new List<Product>();
            if (_context.products == null)
            {
                return NotFound();
            }
            int i = 0;
            foreach (Product produit in _context.products)
            {
                if (produit.Name == name)
                {
                    tmp_Products.Add(produit);
                }
                i++;
            }
            return tmp_Products;
        }

        


    }
}