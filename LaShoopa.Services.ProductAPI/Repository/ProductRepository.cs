using AutoMapper;
using LaShoopa.Services.ProductAPI.DbContexts;
using LaShoopa.Services.ProductAPI.Models;
using LaShoopa.Services.ProductAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LaShoopa.Services.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _dataBase;
		private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _dataBase = db;
			_mapper = mapper;
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
		{
			Product product = _mapper.Map<ProductDTO, Product>(productDTO);

			if (product.Id > 0)
				_dataBase.Update(product);
			else
				_dataBase.Add(product);

			await _dataBase.SaveChangesAsync();

			return _mapper.Map<Product, ProductDTO>(product);
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			try
			{
				Product product = await _dataBase.Products.Where(u => u.Id == productId).FirstOrDefaultAsync();

				_dataBase.Products.Remove(product);

				await _dataBase.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<ProductDTO> GetProductById(int productId)
		{
			Product product = await _dataBase.Products.Where(u => u.Id == productId).FirstOrDefaultAsync();

			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<IEnumerable<ProductDTO>> GetProducts()
		{
			List<Product> products = await _dataBase.Products.ToListAsync();

			return _mapper.Map<List<ProductDTO>>(products);
		}
	}
}
