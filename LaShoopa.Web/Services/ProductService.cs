using LaShoopa.Web.Models;
using LaShoopa.Web.Models.DTOs;
using LaShoopa.Web.Services.IServices;

namespace LaShoopa.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient) : base (httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDTO,
                Url = SD.ProductApiBase + "/api/products"
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductApiBase + "/api/products/" + productId
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/products/" + productId
            });
        }

        public async Task<T> GetProductsAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/products"
            });
        }

        public async Task<T> UpadateProductAsync<T>(ProductDTO productDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDTO,
                Url = SD.ProductApiBase + "/api/products"
            });
        }
    }
}
