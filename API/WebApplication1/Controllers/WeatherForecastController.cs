using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetProducts")]
        public Products Get()
        {
            Products products = new Products("Voiture","Automobile", "Petite voiture bien", 45.12);

            return products;
        }
    }
}