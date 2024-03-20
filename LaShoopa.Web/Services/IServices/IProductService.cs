using LaShoopa.Web.Models.DTOs;

namespace LaShoopa.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDTO productDTO);
        Task<T> UpadateProductAsync<T>(ProductDTO productDTO);
        Task<T> DeleteProductAsync<T>(int productId);
    }
}
