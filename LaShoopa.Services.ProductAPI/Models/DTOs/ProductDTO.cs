using System.ComponentModel.DataAnnotations;

namespace LaShoopa.Services.ProductAPI.Models.DTOs
{
	public class ProductDTO
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }
		public string Description { get; set; } = string.Empty;
		public string ImageUrl { get; set; }
	}
}
