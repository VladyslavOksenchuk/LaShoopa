using AutoMapper;
using LaShoopa.Services.ProductAPI.Models;
using LaShoopa.Services.ProductAPI.Models.DTOs;

namespace LaShoopa.Services.ProductAPI.Mapper
{
	public class MapperConfig
	{
		public static MapperConfiguration InitializeAutomapper()
		{
			var config = new MapperConfiguration(options =>
			{
				options.CreateMap<Product, ProductDTO>().ReverseMap();
			});

			return config;
		}
	}
}
