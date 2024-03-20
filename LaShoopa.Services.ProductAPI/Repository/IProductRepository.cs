using LaShoopa.Services.ProductAPI.Models.DTOs;

namespace LaShoopa.Services.ProductAPI.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<ProductDTO>> GetProducts();
		Task<ProductDTO> GetProductById(int productId);
		Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
		Task<bool> DeleteProduct(int productId);
	}
}
