using System.ComponentModel.DataAnnotations;

namespace LaShoopa.Services.ProductAPI.Models
{
	public class Product
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; }
    }
}
