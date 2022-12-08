using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SellerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SellerController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAllSeller()
        {
            if (_context.sellers == null)
            {
                return NotFound();
            }
            return await _context.sellers.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetById(int id)
        {
            List<Seller> tmp_Sellers = new List<Seller>();
            if (_context.sellers == null)
            {
                return NotFound();
            }
            int i = 0;
            foreach (Seller seller in _context.sellers)
            {
                if (seller.Id_Seller == id)
                {
                    tmp_Sellers.Add(seller);
                }
                i++;
            }
            return tmp_Sellers;
        }

        [HttpPut]
        public async Task<ActionResult<String>> UpdateSeller(int id, string Newname, string Adress)
        {
            Seller sellers = new Seller();
            if (this._context.sellers.FindAsync(id) == null)
            {
                return NotFound(id);
            }
            sellers = await this._context.sellers.FindAsync(id);
            if (Newname != null)
                sellers.Allias = Newname;
            if (Adress != null)
                sellers.Adress = Adress;
            this._context.sellers.Update(sellers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok($"Le produit {sellers.Allias} a été mis à jours");
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult<String>> DeleteSeller(int id)
        {
            Seller seller = new Seller();
            foreach(Seller? tmp_seller in _context.sellers)
            {
                if (tmp_seller.Id_Seller == id)
                {
                    seller = tmp_seller;
                    foreach(Product? prod in _context.products)
                    {
                        if (prod.Seller == tmp_seller)
                        {
                            _context.products.Remove(prod);
                        }
                    }
                    _context.sellers.Remove(seller);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        return StatusCode(500);
                    }
                }
            }
            return Ok("Ressource créée");

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetByName(string name)
        {
            List<Seller> tmp_Sellers = new List<Seller>();
            if (_context.sellers == null)
            {
                return NotFound();
            }
            int i = 0;
            foreach (Seller seller in _context.sellers)
            {
                if (seller.Allias == name)
                {
                    tmp_Sellers.Add(seller);
                }
                i++;
            }
            return tmp_Sellers;
        }

        [HttpPost]
        public async Task<ActionResult<String>> AddSeller(string allias, string adress)
        {
            Seller nSeller = new Seller { Allias = allias, Adress = adress };
            await _context.sellers.AddAsync(nSeller);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok("Ressource créée");
        }
    }
}