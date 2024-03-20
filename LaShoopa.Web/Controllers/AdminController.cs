using LaShoopa.Web.Models.DTOs;
using LaShoopa.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaShoopa.Web.Controllers
{
	public class AdminController : Controller
	{
		private readonly IProductService _productService;
		public AdminController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			List<ProductDTO> products = new();

			var responce = await _productService.GetProductsAsync<ResponceDTO>();

			if (responce != null && responce.IsSuccess)
				products = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(responce.Result));

			return View(products);
		}

		public async Task<IActionResult> CreateProduct()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProduct(ProductDTO product)
		{
			if (ModelState.IsValid)
			{
				var responce = await _productService.CreateProductAsync<ResponceDTO>(product);

				if (responce != null && responce.IsSuccess)
					return RedirectToAction(nameof(Index));
			}
			return View();
		}
		
		public async Task<IActionResult> DeleteProduct(int productId)
		{
			var responce = await _productService.GetProductByIdAsync<ResponceDTO>(productId);

			if (responce != null && responce.IsSuccess)
			{
				ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(responce.Result));
				return View(model);
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteProduct(ProductDTO product)
		{
			/*if (ModelState.IsValid)
			{*/
				var responce = await _productService.DeleteProductAsync<ResponceDTO>(product.Id);

				if (responce.IsSuccess)
					return RedirectToAction(nameof(Index));
			/*}*/
			return View(product);
		}

		/*public async Task<IActionResult> UpdateProduct(int productId)
		{
			var responce = await _productService.GetProductByIdAsync<ResponceDTO>(productId);

			if(responce != null && responce.IsSuccess)
				return View(responce);

			return View();
		}

		[HttpDelete]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateProduct()
		{
			if (ModelState.IsValid)
			{
				var responce = await _productService.DeleteProductAsync<ResponceDTO>(3);

				if (responce != null && responce.IsSuccess)
					return RedirectToAction(nameof(Index));
			}
			return View();
		}*/
	}
}
