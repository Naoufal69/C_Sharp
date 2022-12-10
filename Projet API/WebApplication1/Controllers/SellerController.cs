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

        /* It's the constructor of the class. */
        public SellerController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        /// <summary>
        /// This function is used to get all the sellers from the database
        /// </summary>
        /// <returns>
        /// A list of sellers.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAllSeller()
        {
            if (_context.sellers == null)
            {
                return NotFound();
            }
            return await _context.sellers.ToListAsync();
        }

        /// <summary>
        /// It returns a list of sellers with the same id as the one passed in the url
        /// </summary>
        /// <param name="id">int - the id of the seller</param>
        /// <returns>
        /// A list of sellers with the specified id.
        /// </returns>
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

        /// <summary>
        /// It's a function that updates a seller's name and address.
        /// </summary>
        /// <param name="id">the id of the seller to update</param>
        /// <param name="Newname">The new name of the seller</param>
        /// <param name="Adress">string</param>
        /// <returns>
        /// The seller's name and address.
        /// </returns>
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

        /// <summary>
        /// It deletes a seller and all his products
        /// </summary>
        /// <param name="id">the id of the seller to delete</param>
        /// <returns>
        /// The method returns a string.
        /// </returns>
        [HttpDelete("id")]
        public async Task<ActionResult<String>> DeleteSeller(int id)
        {
            if (id < 0) {
                return NotFound("Ressource non trouvé");
            }
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

        [/// <summary>
        /// It takes a string as a parameter, and returns a list of sellers that have the same name as
        /// the string
        /// </summary>
        /// <param name="name">the name of the seller</param>
        /// <returns>
        /// A list of sellers with the same name.
        /// </returns>
        HttpGet("{name}")]
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

        /// <summary>
        /// It adds a seller to the database
        /// </summary>
        /// <param name="allias">string</param>
        /// <param name="adress">"string"</param>
        /// <returns>
        /// The method returns a string.
        /// </returns>
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