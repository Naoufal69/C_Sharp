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