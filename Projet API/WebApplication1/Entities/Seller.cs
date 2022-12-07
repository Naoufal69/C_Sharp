using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Seller
    {
        [Key]
        public int Id_Seller { get; set; }
        [Required]
        public string Allias { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
