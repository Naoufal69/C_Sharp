using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication1.Controllers{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase{
        private static List<Products> products = new List<Products>{
            new Products {Id = 1, Name = "Voiture audi", Price = 45.12 },
            new Products {Id = 2, Name = "Maison", Price = 156123.56 },
            new Products {Id = 3, Name = "Téléphone", Price = 125.99 },
            new Products {Id = 4, Name = "Jouets enfants", Price = 10.50 },
            new Products {Id = 5, Name = "Lampe", Price = 20.00 },
            new Products {Id = 6, Name = "Stylo", Price = 0.99 }
        };

        [HttpGet]
        public ActionResult<List<Products>> GetProducts(){
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
        public ActionResult<List<Products>> DeleteProducts(int id)
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
        public ActionResult<List<Products>> PostProducts(string name,double price)
        {
            Products newProducts = new Products { Id = products.Count+1, Name = name, Price = price };
            products.Add(newProducts);
            return Ok(products);
        }

        [HttpPost("{id:int}")]
        public ActionResult<List<Products>> UpdateProducts(int id,string name, double price)
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