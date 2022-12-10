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

        /* The constructor of the class. It is used to initialize the class. */
        public ProductsController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        /// <summary>
        /// This function is used to get all the products from the database
        /// </summary>
        /// <returns>
        /// A list of products.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            return await _context.products.ToListAsync();
        }

        /// <summary>
        /// It returns a list of products that have the same id as the one passed in the url
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>
        /// A list of products
        /// </returns>
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

        /// <summary>
        /// It deletes a product from the database
        /// </summary>
        /// <param name="id">the id of the product to delete</param>
        /// <returns>
        /// The product is being deleted from the database.
        /// </returns>
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
            return Ok("Produit supprim�");
        }


        /// <summary>
        /// It returns a list of products that have the same name as the one passed in the URL
        /// </summary>
        /// <param name="name">The name of the product you want to get.</param>
        /// <returns>
        /// A list of products with the name specified in the URL
        /// </returns>
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

        /// <summary>
        /// This function is used to update a product in the database.
        /// </summary>
        /// <param name="id">the id of the product to update</param>
        /// <param name="Newname">The new name of the product</param>
        /// <param name="price">double</param>
        /// <returns>
        /// The method returns a string.
        /// </returns>
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
            return Ok($"Le produit {product.Name} a �t� mis � jours");
        }

        /// <summary>
        /// It adds a product to the database, but only if the seller exists
        /// </summary>
        /// <param name="id_Seller">the id of the seller</param>
        /// <param name="price">double</param>
        /// <param name="name">the name of the product</param>
        /// <returns>
        /// The method returns a string.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<String>> AddProduct(int id_Seller,double price,string name)
        {

            bool found = false;
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
                return Ok("Ressource cr�e");
            else 
                return NotFound("Vendeur inconnu");
        }

        


    }
}