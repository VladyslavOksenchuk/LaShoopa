using Azure;
using LaShoopa.Services.ProductAPI.Models.DTOs;
using LaShoopa.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LaShoopa.Services.ProductAPI.Controllers
{
	[Route("/api/products")]
	public class ProductAPIController : Controller
	{
		private readonly IProductRepository _productRepository;
		private ResponceDTO _responce;

		public ProductAPIController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
			_responce = new ResponceDTO();
		}

		[HttpGet]
		public async Task<object> GetAllProducts()
		{
			try
			{
				IEnumerable<ProductDTO> products = await _productRepository.GetProducts();

				_responce.Result = products;
			}
			catch (Exception ex)
			{
				_responce.IsSuccess = false;
				_responce.Error = "GetAllProducts Error";
				_responce.Message = new List<string>() { ex.ToString() };
			}

			return _responce;
		}

		[HttpGet]
		[Route("{productId}")]
		public async Task<object> GetProductById(int productId)
		{
			try
			{
				ProductDTO product = await _productRepository.GetProductById(productId);

				_responce.Result = product;
			}
			catch (Exception ex)
			{
				_responce.IsSuccess = false;
				_responce.Error = "GetProductById Error";
				_responce.Message = new List<string>() { ex.ToString() };
			}
			return _responce;
		}

		[HttpPost]
		public async Task<object> CreateProduct([FromBody] ProductDTO productDTO)
		{
			try
			{
				ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);

				_responce.Result = model;
			}
			catch (Exception ex)
			{
				_responce.IsSuccess = false;
				_responce.Error = "CreateProduct Error";
				_responce.Message = new List<string>() { ex.ToString() };
			}
			return _responce;
		}

		[HttpPut]
		public async Task<object> UpdateProduct([FromBody] ProductDTO productDTO)
		{
			try
			{
				ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);

				_responce.Result = model;
			}
			catch (Exception ex)
			{
				_responce.IsSuccess = false;
				_responce.Error = "UpdateProduct Error";
				_responce.Message = new List<string>() { ex.ToString() };
			}
			return _responce;
		}
		
		[HttpDelete]
		[Route("{productId}")]
		public async Task<object> DeleteProduct(int productId)
		{
			try
			{
				bool result = await _productRepository.DeleteProduct(productId);

				_responce.Result = result;
			}
			catch (Exception ex)
			{
				_responce.IsSuccess = false;
				_responce.Error = "DeleteProduct Error";
				_responce.Message = new List<string>() { ex.ToString() };
			}
			return _responce;
		}
	}
}
