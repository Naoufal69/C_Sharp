using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication1.Controllers{
    [ApiController]
    [Route("api/CRUD/[controller]")]

    public class ProductsController : ControllerBase{
        private static List<Product> products = new List<Product>{
            new Product {Id = 1, Name = "Voiture audi", Price = 45.12 },
            new Product {Id = 2, Name = "Maison", Price = 156123.56 },
            new Product {Id = 3, Name = "Téléphone", Price = 125.99 },
            new Product {Id = 4, Name = "Jouets enfants", Price = 10.50 },
            new Product {Id = 5, Name = "Lampe", Price = 20.00 },
            new Product {Id = 6, Name = "Stylo", Price = 0.99 }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetProducts(){
            return Ok(products);
        }

        /// <summary>
        /// The function deletes a product from the list of products
        /// </summary>
        /// <param name="id">int - This is the parameter that will be passed in the URL.</param>
        /// <returns>
        /// The action result is a list of products.
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult<List<Product>> DeleteProducts(int id)
        {
            if (id < 0 || id > products.Count)
                return NotFound(products);
            else
            {
                products.RemoveAt(id - 1);
                return Ok(products);
            }
        }

        [HttpPost]
        public ActionResult<List<Product>> PostProducts(string name,double price)
        {
            Product newProducts = new Product { Id = products.Count+1, Name = name, Price = price };
            products.Add(newProducts);
            return Ok(products);
        }

        [HttpPost("{id:int}")]
        public ActionResult<List<Product>> UpdateProducts(int id,string name, double price)
        {
            if (id < 0 || id > products.Count)
                return NotFound(products);
            else
            {
                products[id - 1].Name = name;
                products[id - 1].Price = price;
                return Ok(products);
            }
        }
    }
}