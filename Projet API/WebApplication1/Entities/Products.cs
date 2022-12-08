using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public Seller? Fk_ { get; set;}
}