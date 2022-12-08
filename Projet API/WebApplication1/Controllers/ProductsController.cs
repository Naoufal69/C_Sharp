using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApplication1.Entities;

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

        [HttpPost]
        public async Task<ActionResult<String>> AddProduct(int id_Seller,double price,string name)
        {

            bool found = false;
            foreach (Seller seller in _context.sellers)
            {
                if (seller.Id_Seller == id_Seller)
                {
                    Product product = new Product { Fk_ = seller, Price = price, Name = name };
                    await _context.products.AddAsync(product);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        return StatusCode(500);
                    }
                    found = true;
                }
            }

            if (found)
                return Ok("Ressource crée");
            else 
                return NotFound("Vendeur inconnu");
        }

        


    }
}