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

        [HttpDelete("id")]
        public async Task<ActionResult<String>> DeleteProduct(int id)
        {
            Product product = new Product();
            if (this._context.products.FindAsync(id) == null)
            {
                return NotFound(id);
            }
            product = await this._context.products.FindAsync(id);
            this._context.products.Remove(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok("Produit supprimé");
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

        [HttpPut]
        public async Task<ActionResult<String>> UpdateProduct(int id,string Newname,double price)
        {
            Product product = new Product();
            if (this._context.products.FindAsync(id) == null)
            {
                return NotFound(id);
            }
            product = await this._context.products.FindAsync(id);
            if (Newname == null)
                product.Name = "Aucun nom";
            else
                product.Name = Newname;
            if (price != null && price > 0)
            {
                product.Price = price;
            }
            this._context.products.Update(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok($"Le produit {product.Name} a été mis à jours");
        }

        [HttpPost]
        public async Task<ActionResult<String>> AddProduct(int id_Seller,double price,string name)
        {

            bool found = false;

            //// find vendeur 
            //var vendeur = await this._context.sellers.FindAsync(id_Seller);
            //   if (vendeur != null)
            //{
            //    Product newProduct =  new Product
            //    {
            //        Seller = vendeur,
            //        Price = price,
            //        Name = name
            //    };
            //    await this._context.products.AddAsync(newProduct);

            //    await this._context.SaveChangesAsync();

            //    return Created($"product/{newProduct.Id}", newProduct);
            //}
            //   return BadRequest(string.Empty);
            // add PRoduct



            foreach (Seller seller in _context.sellers)
            {
                if (seller.Id_Seller == id_Seller)
                {
                    Product product = new Product { Seller = seller, Price = price, Name = name };
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